﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Unreal.Core.Models
{
    public class FFastArraySerializerHeader
    {
        public int ArrayReplicationKey { get; internal set; }
        public int BaseReplicationKey { get; internal set; }
        public int NumChanged { get; internal set; }
        public int NumDeleted { get; internal set; }
    }
}
