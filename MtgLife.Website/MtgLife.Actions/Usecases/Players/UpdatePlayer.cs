using MtgLife.Data.Repositories;
using MtgLife.Shared;
using MtgLife.Shared.Entities;

namespace MtgLife.Actions.Usecases.Players
{
    public class UpdatePlayerInteractor
    {
        public UpdatePlayerResponse Invoke(UpdatePlayerRequest request)
        {
            var game = UpdatePlayer(request);
            return CreateResponse(game);
        }

        private Player UpdatePlayer(UpdatePlayerRequest request)
        {
            var repository = new PlayerRepository();
            var newPlayer = request.Assign<Player>();
            repository.Replace(newPlayer);

            return newPlayer;
        }

        private UpdatePlayerResponse CreateResponse(Player player)
        {
            return new UpdatePlayerResponse { PlayerId = player._id.ToString() };
        }
    }

    public struct UpdatePlayerRequest
    {
        public string GameId { get; set; }
        public string PlayerName { get; set; }
    }

    public struct UpdatePlayerResponse
    {
        public string PlayerId { get; set; }
    }
}
