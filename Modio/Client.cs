using System;
using System.Net.Http;
using System.Threading.Tasks;

using Modio.Http;
using Modio.Models;

namespace Modio;

/// <summary>
/// A Client for the mod.io API v1.
/// </summary>
public partial class Client
{
    /// <summary>
    /// Default host url for the mod.io API v1.
    /// </summary>
    public static readonly Uri ModioApiUrl = new("https://api.mod.io/v1/");

    /// <summary>
    /// Host url for the mod.io test environment API v1.
    /// </summary>
    public static readonly Uri ModioApiTestUrl = new("https://api.test.mod.io/v1/");

    private IConnection connection;

    /// <summary>
    /// Client for the Authentication API.
    /// </summary>
    public AuthClient Auth { get; private set; }

    /// <summary>
    /// Client for the Games API.
    /// </summary>
    public GamesClient Games { get; private set; }

    /// <summary>
    /// Client for the User API.
    /// </summary>
    public UserClient User { get; private set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Client"/> with <paramref name="credentials"/>.
    /// </summary>
    public Client(Credentials credentials) : this(new Connection(ModioApiUrl, credentials.ApiKey, credentials.Token))
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Client"/> with a custom host and <paramref name="credentials"/>.
    /// </summary>
    public Client(Uri baseUrl, Credentials credentials) : this(new Connection(FixBaseUrl(baseUrl), credentials.ApiKey, credentials.Token))
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="Client"/> with a custom host, custom <paramref name="credentials"/>, and a custom <paramref name="httpClient"/>.
    /// </summary>
    public Client(Uri baseUrl, Credentials credentials, HttpClient httpClient) : this(new Connection(FixBaseUrl(baseUrl), credentials.ApiKey, credentials.Token, httpClient))
    {
    }

    private Client(IConnection connection)
    {
        this.connection = connection;
        Auth = new AuthClient(connection);
        Games = new GamesClient(connection);
        User = new UserClient(connection);
    }

    /// <summary>
    /// Report a resource on mod.io.
    /// </summary>
    public async Task SubmitReport(NewReport report)
    {
        var (method, path) = Routes.SubmitReport();
        var req = new Request(method, path, report.ToContent());

        await connection.Send<ApiMessage>(req);
    }

    static Uri FixBaseUrl(Uri uri)
    {
        Ensure.ArgumentNotNull(uri, nameof(uri));
        if (uri.Host.Equals("api.mod.io"))
        {
            return ModioApiUrl;
        }
        if (uri.Host.Equals("api.test.mod.io"))
        {
            return ModioApiTestUrl;
        }

        return new Uri(uri, new Uri("/v1/", UriKind.Relative));
    }
}