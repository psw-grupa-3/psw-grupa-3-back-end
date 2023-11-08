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

        [HttpPut("followers/{userId:int}/follow/{userToFollowId:int}")]
        public ActionResult<UserProfileDto> Follow(int userId, int userToFollowId)
        {
            var result = _userFollowerService.Follow(userId, userToFollowId);
            return CreateResponse(result);
        }

        [HttpGet("followers/{userId:int}")]
        public ActionResult<List<FollowerDto>> GetFollowers(int userId)
        {
            var result = _userFollowerService.GetFollowers(userId);
            return CreateResponse(result);
        }

        [HttpPut("followers/{userId:int}/unfollow/{userToUnfollowId:int}")]
        public ActionResult<UserProfileDto> Unfollow(int userId, int userToUnfollowId)
        {
            var result = _userFollowerService.Unfollow(userId, userToUnfollowId);
            return CreateResponse(result);
        }

    }
}
