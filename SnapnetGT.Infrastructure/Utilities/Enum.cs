﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Infrastructure.Utilities
{
    public class Enum
    {
        public enum Filter
        {
            None,
            Name,
            Description
        }

        public enum Status
        {
            Pending,
            Processing,
            Delivered
        }
    }
}
