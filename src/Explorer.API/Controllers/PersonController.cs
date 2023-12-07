using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers
{
    [Authorize(Policy = "allRolesPolicy")]
    [Route("api/userprofile")]
    public class PersonController : BaseApiController
    {
        private readonly IPersonService _personService;
        private readonly IUserFollowerService _userFollowerService;

        public PersonController(IPersonService personService, IUserFollowerService userFollowerService)
        {
            _personService = personService;
            _userFollowerService = userFollowerService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<PagedResult<PersonDto>> GetPerson(int id) {
            var result = _personService.GetPersonByUserId(id);
            return CreateResponse(result);
        }

        [HttpGet("allUsers")]
        public ActionResult<IEnumerable<UserDto>> GetAllUsers()
        {
            var result = _userFollowerService.GetAll();
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<PersonDto> Update([FromBody] PersonDto personDto)
        {
            var result = _personService.Update(personDto);
            return CreateResponse(result);
        }

        [HttpPatch("followers/{userId:int}/follow/{userToFollowId:int}")]
        public ActionResult<PersonDto> Follow(int userId, int userToFollowId)
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
        public ActionResult<PersonDto> Unfollow(int userId, int userToUnfollowId)
        {
            var result = _userFollowerService.Unfollow(userId, userToUnfollowId);
            return CreateResponse(result);
        }

    }
}
