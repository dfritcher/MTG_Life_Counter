using MtgLife.Data.Repositories;
using MtgLife.Shared;
using MtgLife.Shared.Entities;

namespace MtgLife.Actions.Usecases.Players
{
    public class GetPlayerInteractor
    {
        public GetPlayerResponse Invoke(GetPlayerRequest request)
        {
            var game = GetPlayer(request);
            return CreateResponse(game);
        }

        private Player GetPlayer(GetPlayerRequest request) {
            var repository = new PlayerRepository();
            return repository.Get(request.PlayerId);
        }

        private GetPlayerResponse CreateResponse(Player player)
        {
            var response = player.Assign<GetPlayerResponse>();
            response.PlayerId = player._id.ToString();
            return response;
        }
    }

    public struct GetPlayerRequest
    {
        public string PlayerId { get; set; }
    }

    public struct GetPlayerResponse
    {
        public string PlayerId { get; set; }
        public string GameId { get; set; }
        public string PlayerName { get; set; }
        public int LifeTotal { get; set; }
    }
}
