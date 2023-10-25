using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/points")]
    public class PointsController : BaseApiController
    {
        private readonly IPointsService _pointsService;

        public PointsController(IPointsService pointsService)
        {
            _pointsService = pointsService;
        }

        [HttpGet]
        public ActionResult<PagedResult<PointsDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _pointsService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<PointsDto> Create([FromBody] PointsDto points)
        {
            var result = _pointsService.Create(points);
            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<PointsDto> Update([FromBody] PointsDto points)
        {
            var result = _pointsService.Update(points);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _pointsService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("getAllForTour/{id}")]
        [AllowAnonymous]
        public ActionResult GetAllForTour(int id)
        {
            var result = _pointsService.GetAllForTour(id);
            return CreateResponse(result);
        }
    }
}
