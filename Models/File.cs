using System;
using System.Text.Json.Serialization;

namespace Modio.Models
{
    public class File
    {
        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("mod_id")]
        public uint ModId { get; set; }

        [JsonPropertyName("date_added")]
        public long DateAdded { get; set; }

        [JsonPropertyName("date_scanned")]
        public long DateScanned { get; set; }

        [JsonPropertyName("virus_status")]
        public uint VirusStatus { get; set; }

        [JsonPropertyName("virus_positive")]
        public uint VirusPositive { get; set; }

        [JsonPropertyName("virustotal_hash")]
        public string? VirusTotalHash { get; set; }

        [JsonPropertyName("filesize")]
        public long FileSize { get; set; }

        [JsonPropertyName("filehash")]
        public FileHash? FileHash { get; set; }

        [JsonPropertyName("filename")]
        public string? Filename { get; set; }

        [JsonPropertyName("version")]
        public string? Version { get; set; }

        [JsonPropertyName("changelog")]
        public string? Changelog { get; set; }

        [JsonPropertyName("metadata_blob")]
        public string? MetadataBlob { get; set; }

        [JsonPropertyName("download")]
        public Download? Download { get; set; }
    }

    public class FileHash
    {
        [JsonPropertyName("md5")]
        public string? Md5 { get; set; }
    }

    public class Download
    {
        [JsonPropertyName("binary_url")]
        public Uri? BinaryUrl { get; set; }

        [JsonPropertyName("date_expires")]
        public long ExpiredAt { get; set; }
    }
}
