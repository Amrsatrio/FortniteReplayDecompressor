﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FortniteReplayReader.Models
{
    public class Team
    {
        public List<Player> Players { get; internal set; } = new List<Player>();
    }
}
