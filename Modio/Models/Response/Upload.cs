using System;
using System.Text.Json.Serialization;

namespace Modio.Models;

/// <remarks>
/// https://docs.mod.io/restapiref/#multipart-upload-object
/// </remarks>
public class UploadSession
{
    /// <summary>
    /// Unique upload id (UUID).
    /// </summary>
    [JsonPropertyName("upload_id")]
    public Guid Id { get; set; }

    /// <summary>
    /// The status of the upload session.
    /// </summary>
    [JsonPropertyName("status")]
    public SessionStatus Status { get; set; }
}

/// <summary>
/// Status of a Upload session.
/// </summary>
public enum SessionStatus
{
    /// <summary>
    /// Incomplete
    /// </summary>
    Incomplete = 0,
    /// <summary>
    /// Pending
    /// </summary>
    Pending = 1,
    /// <summary>
    /// Processing
    /// </summary>
    Processing = 2,
    /// <summary>
    /// Completed
    /// </summary>
    Completed = 3,
    /// <summary>
    /// Cancelled
    /// </summary>
    Cancelled = 4,
}

/// <remarks>
/// https://docs.mod.io/restapiref/#multipart-upload-part-object
/// </remarks>
public class UploadPart
{
    /// <summary>
    /// Unique upload id (UUID).
    /// </summary>
    [JsonPropertyName("upload_id")]
    public Guid UploadId { get; set; }

    /// <summary>
    /// The part number this part represents.
    /// </summary>
    [JsonPropertyName("part_number")]
    public uint PartNumber { get; set; }

    /// <summary>
    /// The size of this part in bytes.
    /// </summary>
    [JsonPropertyName("part_size")]
    public uint Size { get; set; }

    /// <summary>
    /// Unix timestamp of date the part was uploaded.
    /// </summary>
    [JsonPropertyName("date_added")]
    public long DateAdded { get; set; }
}