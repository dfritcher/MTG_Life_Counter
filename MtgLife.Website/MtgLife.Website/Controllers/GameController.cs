using System.Web.Mvc;
using MtgLife.Actions.Usecases.Players;
using MtgLife.Shared;
using MtgLife.Website.Models;

namespace MtgLife.Website.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Show()
        {
            if (Url.RequestContext.RouteData.Values["id"] == null) Redirect("/");

            var playerId = Url.RequestContext.RouteData.Values["id"].ToString();
            var player = GetPlayer(playerId);

            var viewModel = player.Assign<PlayerViewModel>();
            return View(viewModel);
        }


        private GetPlayerResponse GetPlayer(string id)
        {
            var getPlayer = new GetPlayerInteractor();
            var request = new GetPlayerRequest
            {
                PlayerId = id
            };
            return getPlayer.Invoke(request);
        }
    }
}