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
        public ActionResult Index(GameViewModel viewModel) {
            var game = CreateNewGame(viewModel);
            var player = CreatePlayer(viewModel, game);

            return Redirect("/Game/Show/" + player.PlayerId);
        }

        private static CreateNewGameResponse CreateNewGame(GameViewModel viewModel) {
            var createNewGame = new CreateNewGameInteractor();
            var request = new CreateNewGameRequest {
                StartingLifeTotal = viewModel.StartingLifeTotal,
            };
            var response = createNewGame.Invoke(request);
            return response;
        }
        private static CreateNewPlayerResponse CreatePlayer(GameViewModel viewModel, CreateNewGameResponse game) {
            var createNewPlayer = new CreateNewPlayerInteractor();
            var request = new CreateNewPlayerRequest {
                GameId = game.GameId,
                PlayerName = viewModel.PlayerName,
                LifeTotal = viewModel.StartingLifeTotal
            };
            return createNewPlayer.Invoke(request);
        }
    }
}