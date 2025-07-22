using System;

namespace Modio;

/// <summary>
/// Represents errors that occur when downloading mod files.
/// </summary>
public class DownloadException : Exception
{
    /// <summary>
    /// Creates a new instance of DownloadException.
    /// </summary>
    public DownloadException()
    {
    }

    /// <summary>
    /// Creates a new instance of DownloadException.
    /// </summary>
    public DownloadException(string message, Exception innerException) : base(message, innerException)
    {
    }
}