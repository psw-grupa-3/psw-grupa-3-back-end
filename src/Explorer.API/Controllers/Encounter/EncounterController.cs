using Explorer.Blog.API.Dtos;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Encounter
{
    //[Authorize(Policy = "administratorPolicy")]
    [Route("api/encounters")]
    public class EncounterController: BaseApiController
    {
        private readonly IEncounterService _encounterService;

        public EncounterController(IEncounterService encounterService)
        {
            _encounterService = encounterService;
        }

        [HttpPost("create")]
        public ActionResult<EncounterDto> Create([FromBody] EncounterDto encounter)
        {
            var result = _encounterService.Create(encounter);
            return CreateResponse(result);
        }

        [HttpGet("get/{encounterId:int}")]
        public ActionResult<EncounterDto> Get([FromRoute] int encounterId)
        {
            return CreateResponse(_encounterService.Get(encounterId));
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public ActionResult<EncounterDto> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_encounterService.GetPaged(page, pageSize));
        }

    }
}
