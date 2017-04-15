using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgLife.Actions.Usecases.Games
{
    public class CreateNewGameInteractor
    {
        public CreateNewGameResponse Invoke(CreateNewGameRequest request) {
            CreateNewGame(request);
        }

        private Game CreateNewGame(CreateNewGameRequest request) { }
        
    }
    
    public struct CreateNewGameRequest
    {
        public int LifeTotal { get; set; }
        public string PlayerName { get; set; }
    }

    public struct CreateNewGameResponse
    {
        public string GameId { get; set; }
    }
}
