using System.Web.Mvc;
using MtgLife.Actions.Usecases.Players;
using MtgLife.Shared;
using MtgLife.Website.Models;

namespace MtgLife.Website.Controllers
{
    public class PlayerController : Controller
    {
        [HttpPost]
        public ActionResult AddOneToTotal(PlayerViewModel viewModel) {
            UpdatePlayer(viewModel.PlayerId);

            return Json("Success");
        }

        private void UpdatePlayer(string playerId) {
            var addOneToTotal = new AddOneToTotalInteractor();
            var request = new AddOneToTotalRequest {PlayerId = playerId};
            addOneToTotal.Invoke(request);
        }
    }
}