namespace Modio
{
    /// <summary>
    /// Base class for API endpoint clients.
    /// </summary>
    public abstract class ApiClient
    {
        internal ApiClient(IConnection connection)
        {
            Connection = connection;
        }

        internal IConnection Connection { get; private set; }
    }
}
