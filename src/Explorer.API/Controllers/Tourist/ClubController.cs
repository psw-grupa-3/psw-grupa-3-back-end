using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    //[Authorize(Policy = "touristPolicy")]
    [Route("api/club")]
    public class ClubController : BaseApiController
    {
        private readonly IClubService _clubService;
      

        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
    
        }

        [HttpPost]
        public ActionResult<ClubRegistrationDto> Create([FromBody] ClubRegistrationDto reg)
        {
            var result = _clubService.Create(reg);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ClubRegistrationDto> Update([FromBody] ClubRegistrationDto reg)
        {
            var result = _clubService.Update(reg);
            return CreateResponse(result);
        }

    }
}
