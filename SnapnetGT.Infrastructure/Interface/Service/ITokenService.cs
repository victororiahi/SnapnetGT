using SnapnetGT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Infrastructure.Interface.Service
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
