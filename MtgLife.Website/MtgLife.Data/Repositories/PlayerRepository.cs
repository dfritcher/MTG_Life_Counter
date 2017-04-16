using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MtgLife.Shared.Entities;

namespace MtgLife.Data.Repositories
{
    public class PlayerRepository : Repository<Player>
    {
        public List<Player> GetAll() {
            var games = ExecuteCollection();
            return games;
        }

        public void Insert(Player player) {
            ExecuteInsert(player);
        }

        public void Replace(Player player) {
            ExecuteReplace(p => p._id == player._id, player);
        }

        public Player Get(string requestPlayerId) {
            return ExecuteCollection(g => g._id == new ObjectId(requestPlayerId)).SingleOrDefault();
        }

        public void AddOneToTotal(string playerId) {
            var player = Get(playerId);
            
            var filter = Builders<Player>.Filter.Eq("_id", new ObjectId(playerId));
            var update = Builders<Player>.Update.Set("LifeTotal", player.LifeTotal + 1);
            ExecuteUpdate(filter, update);
        }
    }
}
