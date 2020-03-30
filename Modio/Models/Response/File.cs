using System;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    /// <remarks>
    /// https://docs.mod.io/#modfile-object
    /// </remarks>
    public class File
    {
        /// <summary>
        /// Unique modfile id.
        /// </summary>
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        /// <summary>
        /// Unique mod id.
        /// </summary>
        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        /// <summary>
        /// Unix timestamp of date file was added.
        /// </summary>
        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        /// <summary>
        /// Unix timestamp of date file was virus scanned.
        /// </summary>
        [JsonPropertyName("date_scanned")]
        public long DateScanned { get; set; }

        /// <summary>
        /// Current virus scan status of the file.
        /// </summary>
        [JsonPropertyName("virus_status")]
        public uint VirusStatus { get; set; }

        /// <summary>
        /// Result of the virus scan.
        /// </summary>
        [JsonPropertyName("virus_positive")]
        public uint VirusPositive { get; set; }

        /// <summary>
        /// VirusTotal proprietary hash to view the scan results.
        /// </summary>
        [JsonPropertyName("virustotal_hash")]
        public string? VirusTotalHash { get; set; }

        /// <summary>
        /// Size of the file in bytes.
        /// </summary>
        [JsonPropertyName("filesize")]
        public long FileSize { get; set; }

        /// <summary>
        /// MD5 hash of the file.
        /// </summary>
        [JsonPropertyName("filehash")]
        public FileHash? FileHash { get; set; }

        /// <summary>
        /// Filename including extension.
        /// </summary>
        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        /// <summary>
        /// Release version this file represents.
        /// </summary>
        [JsonPropertyName("version")]
        public string? Version { get; set; }

        /// <summary>
        /// Changelog for the file.
        /// </summary>
        [JsonPropertyName("changelog")]
        public string? Changelog { get; set; }

        /// <summary>
        /// Metadata stored by the game developer for this file.
        /// </summary>
        [JsonPropertyName("metadata_blob")]
        public string? MetadataBlob { get; set; }

        /// <summary>
        /// Download details of the file.
        /// </summary>
        [JsonPropertyName("download")]
        public Download? Download { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/#filehash-object
    /// </remarks>
    public class FileHash
    {
        /// <summary>
        /// MD5 hash of the file.
        /// </summary>
        [JsonPropertyName("md5")]
        public string? Md5 { get; set; }
    }

    /// <remarks>
    /// https://docs.mod.io/#download-object
    /// </remarks>
    public class Download
    {
        /// <summary>
        /// URL to download the file from the mod.io CDN.
        /// </summary>
        [JsonPropertyName("binary_url")]
        public Uri? BinaryUrl { get; set; }

        /// <summary>
        /// Unix timestamp of when the <c>BinaryUrl</c> will expire.
        /// </summary>
        [JsonPropertyName("date_expires")]
        public long ExpiredAt { get; set; }
    }
}
