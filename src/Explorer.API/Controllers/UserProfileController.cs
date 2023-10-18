using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers
{
    [Authorize(Policy = "allRolesPolicy")]
    [Route("api/profile")]
    public class UserProfileController : BaseApiController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<PagedResult<UserProfileDto>> GetUser([FromQuery] int page, [FromQuery] int pageSize) {
            var result = _userProfileService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<UserProfileDto> Update([FromBody] UserProfileDto profile)
        {
            var result = _userProfileService.Update(profile);
            return CreateResponse(result);
        }
    }
}
