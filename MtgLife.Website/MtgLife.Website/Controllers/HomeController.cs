using System.Web.Mvc;
using MtgLife.Actions.Usecases.Games;
using MtgLife.Actions.Usecases.Players;
using MtgLife.Website.Models;

namespace MtgLife.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GameViewModel viewModel, string submitButton)
        {
            switch (submitButton)
            {
                case "Create game":
                    var game = CreateNewGame(viewModel);
                    var playerCreated = CreatePlayer(viewModel, game.GameId);
                    return Redirect("/Game/Show/" + playerCreated.PlayerId);
                case "Join game":
                    var playerJoined = CreatePlayer(viewModel, viewModel.GameId);
                    return Redirect("/Game/Show/" + playerJoined.PlayerId);
                default:
                    return (View());
            }
        }

        private static CreateNewGameResponse CreateNewGame(GameViewModel viewModel)
        {
            var createNewGame = new CreateNewGameInteractor();
            var request = new CreateNewGameRequest
            {
                StartingLifeTotal = viewModel.StartingLifeTotal,
            };
            var response = createNewGame.Invoke(request);
            return response;
        }
        private static CreateNewPlayerResponse CreatePlayer(GameViewModel viewModel, string gameId)
        {
            var createNewPlayer = new CreateNewPlayerInteractor();
            var request = new CreateNewPlayerRequest
            {
                GameId = gameId,
                PlayerName = viewModel.PlayerName,
                LifeTotal = viewModel.StartingLifeTotal
            };
            return createNewPlayer.Invoke(request);
        }
    }
}