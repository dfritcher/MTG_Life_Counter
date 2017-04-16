using MtgLife.Data.Repositories;
using MtgLife.Shared;
using MtgLife.Shared.Entities;

namespace MtgLife.Actions.Usecases.Games
{
    public class GetGameInteractor
    {
        public GetGameResponse Invoke(GetGameRequest request)
        {
            var game = GetGame(request);
            return CreateResponse(game);
        }

        private Game GetGame(GetGameRequest request) {
            var repository = new GameRepository();
            return repository.Get(request.GameId);
        }

        private GetGameResponse CreateResponse(Game game)
        {
            return game.Assign<GetGameResponse>();
        }
    }

    public struct GetGameRequest
    {
        public string GameId { get; set; }
    }

    public struct GetGameResponse
    {
        public string GameId { get; set; }
        public int StartingLifeTotal { get; set; }
    }
}
