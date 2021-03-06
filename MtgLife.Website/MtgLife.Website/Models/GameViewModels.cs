﻿using System.ComponentModel;

namespace MtgLife.Website.Models
{
    public class GameViewModel
    {
        public string GameId { get; set; }
        public int StartingLifeTotal { get; set; }
        [DisplayName("Player Name")]
        public string PlayerName { get; set; }
    }
}