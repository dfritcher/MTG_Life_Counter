using MtgLife.Data.Repositories;
using MtgLife.Shared;
using MtgLife.Shared.Entities;

namespace MtgLife.Actions.Usecases.Players
{
    public class ChangeTotalInteractor
    {
        public void Invoke(ChangeTotalRequest request)
        {
            ChangeTotal(request);
        }

        private void ChangeTotal(ChangeTotalRequest request)
        {
            var repository = new PlayerRepository();
            repository.ChangeTotal(request.PlayerId, request.NewAmount);
        }
    }

    public struct ChangeTotalRequest
    {
        public string PlayerId { get; set; }
        public int NewAmount { get; set; }
    }
}
