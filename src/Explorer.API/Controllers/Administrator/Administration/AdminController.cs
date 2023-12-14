using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Explorer.Stakeholders.API.Dtos;
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

        [HttpGet("getAll")]
        public ActionResult<UserDto> GetAll()
        {
            return CreateResponse(_userService.GetAll());
        }

        [HttpPost("block-users")]
        public IActionResult BlockUsers([FromBody] List<string> usernames)
        {
            try
            {
                foreach (var username in usernames)
                {
                    _userService.Block(username);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Greška prilikom blokiranja korisnika: {ex.Message}");
            }
        }
    }
}
