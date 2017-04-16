using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgLife.Shared.Entities
{
    public class Player : BaseEntity
    {
        public string GameId { get; set; }
        public string PlayerName { get; set; }
        public int LifeTotal { get; set; }
    }
}
