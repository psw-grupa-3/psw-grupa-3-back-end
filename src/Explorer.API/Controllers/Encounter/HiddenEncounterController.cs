using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Encounter
{
    [Route("api/hidden-encounters")]
    public class HiddenEncounterController : BaseApiController
    {
        private readonly IHiddenEncounterService _encounterService;

        public HiddenEncounterController(IHiddenEncounterService service)
        {
            _encounterService = service;
        }


        [Authorize(Policy = "touristPolicy")]
        [HttpPut("solve-hidden/{encounterId:int}")]
        public ActionResult<HiddenEncounterDto> SolveHidden([FromRoute] int encounterId, [FromBody] ParticipantLocationDto locationDto)
        {
            //return CreateResponse(_encounterService.Solve(encounterId, locationDto));
            throw new NotImplementedException();
        }
    }
}
