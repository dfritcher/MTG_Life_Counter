using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MtgLife.Shared;
using MtgLife.Shared.Entities;

namespace MtgLife.Data.Repositories
{
    public class GameRepository : Repository<Game>
    {
        public List<Game> GetAll() {
            var games = ExecuteCollection();
            return games;
        }

        public void Insert(Game game) {
            game.GameId = RandomIdGenerator.GetBase62(6);
            ExecuteInsert(game);
        }

        public Game Get(string requestGameId) {
            return ExecuteCollection(g => g.GameId == requestGameId).SingleOrDefault();
        }
    }
}
