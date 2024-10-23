using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SnapnetGT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
    }
}
