﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtgLife.Shared.Entities
{
    public class Game : BaseEntity
    {
        public string GameId { get; set; }
        public int StartingLifeTotal { get; set; }
    }
}
