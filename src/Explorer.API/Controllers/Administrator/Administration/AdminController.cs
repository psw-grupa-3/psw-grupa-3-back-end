using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Stakeholders.API.Public;

namespace Explorer.API.Controllers.Admin
{
    [Authorize(Policy = "administratorPolicy")]
    [Route("api/administration/users")]
    public class AdminUserController : BaseApiController
    {
        private readonly IUserService _userService;

        public AdminUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserAdminDto>> GetAllUsers()
        {
            var users = _userService.GetAll(); // Replace with your actual GetAllUsers method
            return Ok(users);
        }

       

        [HttpPost("{id:int}/block")]
        public ActionResult BlockUser(int id)
        {
            _userService.Block(id); // Replace with your actual blocking method
            return NoContent();
        }
    }
}
