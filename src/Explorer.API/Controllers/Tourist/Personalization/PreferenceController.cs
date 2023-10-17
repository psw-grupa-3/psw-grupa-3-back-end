using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Personalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Personalization
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/personalization/preference")]
    public class PreferenceController : BaseApiController
    {
        private readonly IPreferenceService _preferenceService;

        public PreferenceController(IPreferenceService preferenceService)
        {
            _preferenceService = preferenceService;
        }

        [HttpPost]
        public ActionResult<PreferenceDto> Create([FromBody] PreferenceDto preference)
        {
            var result = _preferenceService.Create(preference);
            return CreateResponse(result);
        }
    }
}
