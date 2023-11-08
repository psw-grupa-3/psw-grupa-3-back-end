using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers
{
    [Authorize(Policy = "allRolesPolicy")]
    [Route("api/userprofile")]
    public class UserProfileController : BaseApiController
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IUserFollowerService _userFollowerService;

        public UserProfileController(IUserProfileService userProfileService, IUserFollowerService userFollowerService)
        {
            _userProfileService = userProfileService;
            _userFollowerService = userFollowerService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<PagedResult<UserProfileDto>> GetUser(int id) {
            var result = _userProfileService.GetPersonByUserId(id);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<UserProfileDto> Update([FromBody] UserProfileDto profile)
        {
            var result = _userProfileService.Update(profile);
            return CreateResponse(result);
        }

        [HttpPut("{followerId:int}/follow/{userToFollowId:int}")]
        public ActionResult<UserProfileDto> Follow(int followerId, int userToFollowId)
        {
            var result = _userFollowerService.Follow(followerId, userToFollowId);
            return CreateResponse(result);
        }


    }
}
