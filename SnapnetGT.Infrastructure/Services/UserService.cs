using Microsoft.AspNetCore.Identity;
using SnapnetGT.Data.Entities;
using SnapnetGT.Infrastructure.DTOs;
using SnapnetGT.Infrastructure.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapnetGT.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        public UserService(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }


        public async Task<bool> CreateUser(UserSignupDTO userSignupDTO)
        {
            //Check if the user exists
            var user = await _userManager.FindByEmailAsync(userSignupDTO.Email);
            if (user != null)
            {
                throw new Exception($"User : {userSignupDTO.Email} already exists!");
            }

            //Create the object of user entity
            var newUser = new User
            {
                FirstName = userSignupDTO.FirstName,
                LastName = userSignupDTO.LastName,
                Email = userSignupDTO.Email,
                UserName = userSignupDTO.Email,
                EmailConfirmed = true

            };


            //Add object from user to users table
            var result = await _userManager.CreateAsync(newUser, userSignupDTO.Password);
            if (!result.Succeeded)
            {
                throw new Exception($"Something went wrong. Failed to create the user : {result.Errors.FirstOrDefault()?.Description}");
            }

            return true;
        }

        //Login
        public async Task<LoginResponseDTO> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                //Check if user exists
                var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);
                if (user == null)
                {
                    throw new Exception("Invalid username or password");
                }


                //Check if password is correct
                var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, userLoginDTO.Password);
                if (result == PasswordVerificationResult.Failed)
                {
                    throw new Exception("Invalid username or password");
                }



                //get token
                var token = _tokenService.GenerateToken(user);


                return new LoginResponseDTO
                {
                    User = new UserDTO()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                        Id = user.Id
                    },
                    Token = token
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
