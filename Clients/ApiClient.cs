namespace Modio
{
    public abstract class ApiClient
    {
        internal ApiClient(IConnection connection)
        {
            Connection = connection;
        }

        internal IConnection Connection { get; private set; }
    }
}
