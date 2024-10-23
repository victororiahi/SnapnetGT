using SnapnetGT.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Infrastructure.Interface.Service
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserSignupDTO userSignupDTO);
        Task<LoginResponseDTO> Login(UserLoginDTO userLoginDTO);
    }
}
