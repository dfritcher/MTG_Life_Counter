using System.Web.Mvc;
using MtgLife.Actions.Usecases.Games;
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
            var createNewGame = new CreateNewGameInteractor();
            var request = new CreateNewGameRequest {
                StartingLifeTotal = 40,
                PlayerName = viewModel.PlayerName
            };
            createNewGame.Invoke(request);

            return Redirect("/");
        }
    }
}