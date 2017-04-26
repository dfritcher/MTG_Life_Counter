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
        [HttpPost]
        public ActionResult RefreshPlayers(PlayerViewModel viewModel)
        {
            var playersInGame = GetCurrentPlayers(viewModel.GameId);
            return Json(playersInGame);
        }

        private void UpdatePlayer(string playerId, int newAmount)
        {
            var changeTotal = new ChangeTotalInteractor();
            var request = new ChangeTotalRequest { PlayerId = playerId, NewAmount = newAmount };
            changeTotal.Invoke(request);
        }
        private GetPlayersInGameResponse GetCurrentPlayers(string gameId)
        {
            var getPlayersInGame = new GetPlayersInGameInteractor();
            var response = getPlayersInGame.Invoke(new GetPlayersInGameRequest { GameId = gameId });
            return response;
        }
    }
}