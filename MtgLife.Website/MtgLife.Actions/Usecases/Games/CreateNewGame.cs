using MtgLife.Data.Repositories;
using MtgLife.Shared;
using MtgLife.Shared.Entities;

namespace MtgLife.Actions.Usecases.Games
{
    public class CreateNewGameInteractor
    {
        public CreateNewGameResponse Invoke(CreateNewGameRequest request)
        {
            var game = CreateNewGame(request);
            return CreateResponse(game);
        }

        private Game CreateNewGame(CreateNewGameRequest request) {
            var repository = new GameRepository();
            var newGame = request.Assign<Game>();
            repository.Insert(newGame);

            return new Game { GameId = "123", StartingLifeTotal = 40 };
        }

        private CreateNewGameResponse CreateResponse(Game game)
        {
            return new CreateNewGameResponse { GameId = game.GameId };
        }
    }

    public struct CreateNewGameRequest
    {
        public int StartingLifeTotal { get; set; }
        public string PlayerName { get; set; }
    }

    public struct CreateNewGameResponse
    {
        public string GameId { get; set; }
    }
}
