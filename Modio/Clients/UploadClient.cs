using System;
using System.Net.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using Modio.Filters;
using Modio.Http;
using Modio.Models;
using File = Modio.Models.File;

namespace Modio;

/// <summary>
/// Client for uploading files.
/// </summary>
class UploadClient : ApiClient
{
    /// The maximum file size (200 MB) before the file is uploaded in multiple parts.
    internal const long MULTIPART_MAX_FILE_SIZE = 200 * 1024 * 1024;

    /// The maximum size a file is partitioned for uploading.
    internal const long MULTIPART_FILE_PART_SIZE = 50 * 1024 * 1024;

    /// <summary>
    /// The game id of the endpoint.
    /// </summary>
    public uint GameId { get; private set; }

    /// <summary>
    /// The mod id of the endpoint.
    /// </summary>
    public uint ModId { get; private set; }

    internal UploadClient(IConnection connection, uint game, uint mod) : base(connection)
    {
        GameId = game;
        ModId = mod;
    }

    /// <summary>
    /// Get all upload sessions for the corresponding mod.
    /// </summary>
    public SearchClient<UploadSession> SearchSessions(Filter? filter = null)
    {
        var route = Routes.GetUploadSessions(GameId, ModId);
        return new SearchClient<UploadSession>(Connection, route, filter);
    }

    /// <summary>
    /// Create a new multipart upload session.
    /// </summary>
    public async Task<UploadSession> CreateSession(string filename, string? nonce = null)
    {
        var parameters = new Parameters {
            {"filename", filename},
        };
        if (nonce != null)
        {
            parameters.Add("nonce", nonce);
        }
        var (method, path) = Routes.CreateUploadSession(GameId, ModId);
        var req = new Request(method, path, parameters.ToContent());
        var resp = await Connection.Send<UploadSession>(req);

        return resp.Body!;
    }

    /// <summary>
    /// Terminate an active multipart upload session.
    /// </summary>
    public async Task DeleteSession(UploadSession session)
    {
        var (method, path) = Routes.DeleteUploadSession(GameId, ModId, session.Id);
        var req = new Request(method, path);
        await Connection.Send<ApiMessage>(req);
    }

    public async Task<UploadSession> CompleteSession(UploadSession session)
    {
        var (method, path) = Routes.CompleteUploadSession(GameId, ModId, session.Id);
        var req = new Request(method, path);
        var resp = await Connection.Send<UploadSession>(req);

        return resp.Body!;
    }

    /// <summary>
    /// Get all uploaded parts for a corresponding upload session.
    /// </summary>
    public async Task<UploadPart[]> GetParts(UploadSession session)
    {
        var (method, path) = Routes.GetUploadParts(GameId, ModId, session.Id);
        var req = new Request(method, path);
        var resp = await Connection.Send<Result<UploadPart>>(req);
        var result = resp.Body!;

        return result.Data.ToArray();
    }

    public async Task<UploadPart> UploadPart(UploadSession session, FileInfo file, long start, long end, IProgress<long>? progress)
    {
        var (method, path) = Routes.AddUploadPart(GameId, ModId, session.Id);

        var stream = file.OpenRead();
        var content = new ByteRangeContent(stream, start, end, file.Length)
        {
            Progress = progress,
        };

        var req = new Request(method, path, content);
        var resp = await Connection.Send<UploadPart>(req);

        return resp.Body!;
    }

    public async Task<File> UploadFile(NewFile newFile, UploadOptions options, CancellationToken cancellationToken = default)
    {
        if (newFile.File.Length > MULTIPART_MAX_FILE_SIZE)
        {
            // 1. Request upload session
            var session = await CreateSession(newFile.File.Name, options.Nonce);

            // 2. Identify if the session has uploaded parts previously.
            var uploadedParts = await GetParts(session);

            var total = newFile.File.Length;
            var ranges = ByteRanges.Create(total, MULTIPART_FILE_PART_SIZE);
            var progress = new Progress(ranges.Length, total, options.Progress);

            foreach (var (i, (start, end)) in ranges)
            {
                // Part numbers start with 1.
                if (Array.Exists(uploadedParts, part => part.PartNumber == i + 1))
                {
                    progress.SkipPart(end - start + 1);
                    continue;
                }

                // 3. Upload every part of the file.
                await UploadPart(session, newFile.File, start, end, progress);

                progress.NextPart();
            }

            // 4. Finalize upload session.
            session = await CompleteSession(session);

            // 5. Upload file with session id.
            var upload = FileUpload.Create(newFile, session.Id);
            return await UploadFile(upload, cancellationToken);
        }
        else
        {
            var progress = new Progress(1, newFile.File.Length, options.Progress);
            // Upload the entire file at once.
            var upload = FileUpload.Create(newFile, progress);
            return await UploadFile(upload, cancellationToken);
        }
    }

    async Task<File> UploadFile(FileUpload upload, CancellationToken cancellationToken = default)
    {
        using var content = upload.ToContent();
        var (method, path) = Routes.AddFile(GameId, ModId);
        var req = new Request(method, path, content);

        var resp = await Connection.Send<File>(req, cancellationToken);
        return resp.Body!;
    }
}

/// <summary>
/// Represents advanced options for uploading files.
/// </summary>
public struct UploadOptions
{
    /// <summary>
    /// An optional nonce to provide to prevent duplicate upload sessions.
    /// </summary>
    public string? Nonce { get; set; }

    /// <summary>
    /// An optional interface for receiving upload progress data.
    /// </summary>
    public IProgress<UploadProgress>? Progress { get; set; }
}

/// <summary>
/// Represent the progress that is reported during a file upload.
/// </summary>
public readonly struct UploadProgress
{
    /// <summary>
    /// Current file part that is uploaded.
    /// </summary>
    public int CurrentPart { get; }

    /// <summary>
    /// Number of parts the file is uploaded.
    /// </summary>
    public int Parts { get; }

    /// <summary>
    /// Current number of bytes uploaded.
    /// </summary>
    public long Position { get; }

    /// <summary>
    /// Total bytes to upload.
    /// </summary>
    public long Total { get; }

    internal UploadProgress(int currentPart, int parts, long position, long total)
    {
        CurrentPart = currentPart;
        Parts = parts;
        Position = position;
        Total = total;
    }
}

class Progress(int parts, long total, IProgress<UploadProgress>? inner) : IProgress<long>
{

    long position = 0;
    int current = 1;

    public void NextPart()
    {
        current++;
    }

    public void SkipPart(long count)
    {
        var progress = this as IProgress<long>;
        progress.Report(count);

        NextPart();
    }

    void IProgress<long>.Report(long value)
    {
        position += value;

        inner?.Report(new UploadProgress(current, parts, position, total));
    }
}

record FileUpload
{
    public string? Version { get; }
    public string? Changelog { get; }
    public bool? Active { get; }
    public string? Filehash { get; }
    public string? MetadataBlob { get; }
    public TargetPlatform[] Platforms { get; }

    public record MultipartUploadCompleted : FileUpload
    {
        public Guid UploadId { get; }

        public MultipartUploadCompleted(NewFile newFile, Guid uploadId) : base(newFile) => UploadId = uploadId;
    }

    public record SingleFilePartUpload : FileUpload
    {
        public FileInfo File { get; }
        public IProgress<long>? Progress { get; }

        public SingleFilePartUpload(NewFile newFile, IProgress<long>? progress) : base(newFile)
        {
            File = newFile.File;
            Progress = progress;
        }
    }

    private FileUpload(NewFile newFile)
    {
        Version = newFile.Version;
        Changelog = newFile.Changelog;
        Active = newFile.Active;
        Filehash = newFile.Filehash;
        MetadataBlob = newFile.MetadataBlob;
        Platforms = newFile.Platforms;
    }

    public static MultipartUploadCompleted Create(NewFile newFile, Guid uploadId) => new(newFile, uploadId);

    public static SingleFilePartUpload Create(NewFile newFile, Progress progress) => new(newFile, progress);

    public HttpContent ToContent()
    {
        var form = this switch
        {
            SingleFilePartUpload fields => new MultipartFormDataContent
            {
                { fields.File.ToContent(fields.Progress), "filedata", fields.File.Name },
            },
            MultipartUploadCompleted fields => new MultipartFormDataContent
            {
                { fields.UploadId.ToString().ToContent(), "upload_id" },
            },
            _ => throw new ArgumentOutOfRangeException(),
        };

        if (Version is string version)
        {
            form.Add(version.ToContent(), "version");
        }
        if (Changelog is string changelog)
        {
            form.Add(changelog.ToContent(), "changelog");
        }
        if (Active is bool active)
        {
            form.Add((active ? "true" : "false").ToContent(), "active");
        }
        if (Filehash is string filehash)
        {
            form.Add(filehash.ToContent(), "filehash");
        }
        if (MetadataBlob is string metadata)
        {
            form.Add(metadata.ToContent(), "metadata_blob");
        }
        foreach (var platform in Platforms)
        {
            form.Add(platform.Value.ToContent(), "platforms[]");
        }

        return form;
    }
}