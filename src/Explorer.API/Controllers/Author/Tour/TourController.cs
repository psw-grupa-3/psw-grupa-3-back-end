using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author.Tour
{
    //[Authorize(Policy = "authorPolicy")]
    [Route("api/author/tour")]
    public class TourController : BaseApiController
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet("getAll")]
        public ActionResult<TourDto> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_tourService.GetPaged(page, pageSize));
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<TourDto> Create([FromBody] TourDto tour)
        {
            return CreateResponse(_tourService.Create(tour));
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourDto> Update([FromBody] TourDto dataIn)
        {

            return CreateResponse(_tourService.Update(dataIn));
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            return CreateResponse(_tourService.Delete(id));
        }

        [HttpPatch("publishTour/{id}")]
        public ActionResult PublishTour(long id)
        {
            return CreateResponse(_tourService.PublishTour(id));
        }

        [HttpPatch("arhiveTour/{id}")]
        public ActionResult ArhiveTour(long id)
        {
            return CreateResponse(_tourService.ArhiveTour(id));
        }
    }
}
