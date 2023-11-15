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

        [HttpGet("getAllPublic")]
        public ActionResult<TourDto> GetAllPublic()
        {
            return CreateResponse(_tourService.GetAllPublic());
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

        [HttpGet("publishTour/{id}")]
        public ActionResult PublishTour(long id)
        {
            return CreateResponse(_tourService.PublishTour(id));
        }

        [HttpGet("arhiveTour/{id}")]
        public ActionResult ArhiveTour(long id)
        {
            return CreateResponse(_tourService.ArhiveTour(id));
        }

        [HttpPost("rateTour/{tourId:int}")]
        [Authorize(Policy = "TouristPolicy")]

        public ActionResult<TourReviewDto> RateTour([FromRoute] int tourId, [FromBody] TourReviewDto tourReview)
        {
            return CreateResponse(_tourService.RateTour(tourId, tourReview));
        }

        [AllowAnonymous]
        [HttpGet("averageRating/{tourId:int}")]
        public ActionResult<double> GetAverageRating(int tourId)
        {
            return CreateResponse(_tourService.GetAverageRating(tourId));
        }


        [AllowAnonymous]
        [HttpGet("searchByPointDistance")]
        public ActionResult<TourDto> SearchByPointDistance([FromQuery] double longitude, [FromQuery] double latitude, [FromQuery] int distance)
        {
            return CreateResponse(_tourService.SearchByPointDistance(longitude, latitude, distance));
        }

        [HttpPatch("publishPoint/{id}")]
        public ActionResult PublishPoint(long id, [FromQuery] string pointName)
        {
            return CreateResponse(_tourService.PublishPoint(id, pointName));
        }
    }
}
