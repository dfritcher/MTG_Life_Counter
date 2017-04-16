using MtgLife.Data.Repositories;
using MtgLife.Shared;
using MtgLife.Shared.Entities;

namespace MtgLife.Actions.Usecases.Players
{
    public class AddOneToTotalInteractor
    {
        public void Invoke(AddOneToTotalRequest request)
        {
            AddOneToTotal(request);
        }

        private void AddOneToTotal(AddOneToTotalRequest request)
        {
            var repository = new PlayerRepository();
            repository.AddOneToTotal(request.PlayerId);
        }
    }

    public struct AddOneToTotalRequest
    {
        public string PlayerId { get; set; }
    }
}
