using MtgLife.Data.Repositories;
using MtgLife.Shared;
using MtgLife.Shared.Entities;

namespace MtgLife.Actions.Usecases.Players
{
    public class CreateNewPlayerInteractor
    {
        public CreateNewPlayerResponse Invoke(CreateNewPlayerRequest request)
        {
            var player = CreateNewPlayer(request);
            return CreateResponse(player);
        }

        private Player CreateNewPlayer(CreateNewPlayerRequest request)
        {
            var repository = new PlayerRepository();
            var newPlayer = request.Assign<Player>();
            repository.Insert(newPlayer);

            return newPlayer;
        }

        private CreateNewPlayerResponse CreateResponse(Player player)
        {
            return new CreateNewPlayerResponse { PlayerId = player._id.ToString() };
        }
    }

    public struct CreateNewPlayerRequest
    {
        public string GameId { get; set; }
        public int LifeTotal { get; set; }
        public string PlayerName { get; set; }
    }

    public struct CreateNewPlayerResponse
    {
        public string PlayerId { get; set; }
    }
}
