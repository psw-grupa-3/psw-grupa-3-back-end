using Explorer.Tours.API.Dtos.Tour.DataIn;
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
        public ActionResult<TourIn> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            return CreateResponse(_tourService.GetPaged(page, pageSize));
        }

        [HttpPost]
        public ActionResult<TourIn> Create([FromBody] TourIn tour)
        {
            return CreateResponse(_tourService.Create(tour));
        }

        [HttpPut("{id:int}")]
        public ActionResult<TourIn> Update([FromBody] TourIn dataIn)
        {

            return CreateResponse(_tourService.Update(dataIn));
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            return CreateResponse(_tourService.Delete(id));
        }
    }
}
