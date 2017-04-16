using System;
using System.Web.Mvc;
using MtgLife.Actions.Usecases.Players;
using MtgLife.Shared;
using MtgLife.Website.Models;

namespace MtgLife.Website.Controllers
{
    public class PlayerController : Controller
    {
        [HttpPost]
        public ActionResult ChangeTotal(PlayerViewModel viewModel)
        {
            UpdatePlayer(viewModel.PlayerId, viewModel.NewAmount);

            return Json("Success");
        }

        private void UpdatePlayer(string playerId, int newAmount)
        {
            var changeTotal = new ChangeTotalInteractor();
            var request = new ChangeTotalRequest { PlayerId = playerId, NewAmount = newAmount };
            changeTotal.Invoke(request);
        }
    }
}