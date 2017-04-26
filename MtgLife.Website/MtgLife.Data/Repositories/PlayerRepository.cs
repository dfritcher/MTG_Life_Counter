using System;
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

        public List<Player> GetAllByGameId(string gameId)
        {
            return ExecuteCollection(g => g.GameId == gameId);
        }

        public Player Get(string requestPlayerId) {
            return ExecuteCollection(g => g._id == new ObjectId(requestPlayerId)).SingleOrDefault();
        }

        public void ChangeTotal(string playerId, int newAmount) {
            var filter = Builders<Player>.Filter.Eq("_id", new ObjectId(playerId));
            var update = Builders<Player>.Update.Set("LifeTotal", newAmount);
            ExecuteUpdate(filter, update);
        }
    }
}
