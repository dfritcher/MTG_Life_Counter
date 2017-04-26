using MtgLife.Data.Repositories;
using MtgLife.Shared;
using MtgLife.Shared.Entities;
using System.Collections.Generic;

namespace MtgLife.Actions.Usecases.Players
{
    public class GetPlayersInGameInteractor
    {
        public GetPlayersInGameResponse Invoke(GetPlayersInGameRequest request)
        {
            var players = GetPlayersInGame(request);
            return CreateResponse(players);
        }

        private List<Player> GetPlayersInGame(GetPlayersInGameRequest request) {
            var repository = new PlayerRepository();
            return repository.GetAllByGameId(request.GameId);
        }

        private GetPlayersInGameResponse CreateResponse(List<Player> players)
        {
            var response = new GetPlayersInGameResponse();
            foreach(var player in players)
            {
                response.Players.Add(player.Assign<PlayerInGame>());
            }

            return response;
        }
    }

    public struct GetPlayersInGameRequest
    {
        public string GameId { get; set; }
    }

    public class GetPlayersInGameResponse
    {
        public GetPlayersInGameResponse()
        {
            Players = new List<PlayerInGame>();
        }
        public List<PlayerInGame> Players { get; set; }
    }

    public struct PlayerInGame
    {
        public string PlayerId { get; set; }
        public string PlayerName { get; set; }
    }
}
