using System.ComponentModel;

namespace MtgLife.Website.Models
{
    public class PlayerViewModel
    {
        public string PlayerId { get; set; }
        public string GameId { get; set; }
        [DisplayName("Player Name")]
        public string PlayerName { get; set; }
        [DisplayName("Life Total")]
        public int LifeTotal { get; set; }
        [DisplayName("Poison Total")]
        public int PoisonTotal { get; set; }

        // Properties for updating
        public int NewAmount { get; set; }
    }
}