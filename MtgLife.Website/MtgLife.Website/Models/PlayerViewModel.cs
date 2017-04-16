using System.ComponentModel;

namespace MtgLife.Website.Models
{
    public class PlayerViewModel
    {
        public string PlayerId { get; set; }
        public string GameId { get; set; }
        [DisplayName("Player Name")]
        public string PlayerName { get; set; }
        public int LifeTotal { get; set; }

        // Properties for updating
        public int NewAmount { get; set; }
    }
}