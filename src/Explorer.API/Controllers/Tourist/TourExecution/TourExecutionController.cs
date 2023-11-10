using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.TourExecution
{
    [Authorize(Policy = "touristPolicy")]
    [Microsoft.AspNetCore.Components.Route("api/tourist/tourExecution")]
    public class TourExecutionController: BaseApiController
    {
        private readonly ITourExecutionService _service;
        public TourExecutionController(ITourExecutionService service)
        {
            _service = service;
        }

        [HttpPost("start-execution/{tourId:int}")]
        public ActionResult<TourExecutionDto> StartExecution([FromRoute] int tourId)
        {
            return CreateResponse(_service.StartExecution(tourId));
        }

        [HttpPatch("quit/{tourExecutionId:int}")]
        public ActionResult<TourExecutionDto> QuitExecution([FromRoute] int tourExecutionId)
        {
            return CreateResponse(_service.QuitExecution(tourExecutionId));
        }

        [HttpPut("update-position/{tourExecutionId:int}")]
        public ActionResult<TourExecutionDto> UpdatePosition([FromBody] PositionDto positionDto,
            [FromRoute] int tourExecutionId)
        {
            return CreateResponse(_service.UpdatePosition(tourExecutionId, positionDto));
        }
    }
}
