using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/clubInvitation")]
    public class ClubInvitationController : BaseApiController
    {
        private readonly IClubInvitationService _clubInvitationService;

        public ClubInvitationController(IClubInvitationService clubInvitationService)
        {
            _clubInvitationService = clubInvitationService;
        }

        [HttpPost]
        public ActionResult<ClubInvitationDto> Create([FromBody] ClubInvitationDto clubInvitation)
        {
            var result = _clubInvitationService.Create(clubInvitation);
            return CreateResponse(result);
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _clubInvitationService.Delete(id);
            return CreateResponse(result);
        }

    }
}
