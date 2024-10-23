﻿using SnapnetGT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Infrastructure.DTOs
{
    public class LoginResponseDTO
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
