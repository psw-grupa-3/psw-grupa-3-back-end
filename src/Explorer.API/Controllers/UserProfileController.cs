using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
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
        private readonly IUserService _userService;

        public UserProfileController(IUserProfileService userProfileService, IUserFollowerService userFollowerService, IUserService userService)
        {
            _userProfileService = userProfileService;
            _userFollowerService = userFollowerService;
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<PagedResult<UserProfileDto>> GetUser(int id) {
            var result = _userProfileService.GetPersonByUserId(id);
            return CreateResponse(result);
        }

        [HttpGet("allUsers")]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var result = _userFollowerService.GetAll();
            return CreateResponse(result);
        }


        [HttpPut("{id:int}")]
        public ActionResult<UserProfileDto> Update([FromBody] UserProfileDto profile)
        {
            var result = _userProfileService.Update(profile);
            return CreateResponse(result);
        }

        [HttpPatch("followers/{userId:int}/follow/{userToFollowId:int}")]
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

        [HttpPatch("followers/{userId:int}/unfollow/{userToUnfollowId:int}")]
        public ActionResult<UserProfileDto> Unfollow(int userId, int userToUnfollowId)
        {
            var result = _userFollowerService.Unfollow(userId, userToUnfollowId);
            return CreateResponse(result);
        }

    }
}
