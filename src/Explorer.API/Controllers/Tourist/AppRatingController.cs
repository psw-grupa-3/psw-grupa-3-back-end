using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]

    // TODO: Smisliti sta ovde treba kao usecase
    [Route("api/tourist/appRating")]
    public class AppRatingController : BaseApiController
    {
        private readonly IAppRatingService _appRatingService;

        public AppRatingController(IAppRatingService appRatingService)
        {
            _appRatingService = appRatingService;
        }

        // TODO: Later
        //[HttpGet]
        //public ActionResult<PagedResult<AppRatingDto>> GetAll([])
        //{

        //}

        [HttpPost]
        public ActionResult<AppRatingDto> Create([FromBody] AppRatingDto appRating)
        {
            var result = _appRatingService.Create(appRating);
            return CreateResponse(result);
        }
    }
}