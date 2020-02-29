using System.Threading.Tasks;

using Modio.Models;

namespace Modio
{
    public class GamesClient : ApiClient
    {
        internal GamesClient(IConnection connection) : base(connection) { }

        public GameClient this[uint game] => new GameClient(Connection, game);
    }
}
