using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace MtgLife.Website.Models
{
    public class GameViewModel {
        public GameViewModel() {
            LifeTotal = 40;
        }
        public int LifeTotal { get; set; }
        public string PlayerName { get; set; }
    }
}