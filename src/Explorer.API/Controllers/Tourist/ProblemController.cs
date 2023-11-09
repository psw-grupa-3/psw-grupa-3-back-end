using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Stakeholders.API.Dtos;

namespace Explorer.API.Controllers.Tourist
{
    [Route("api/tourist/problem")]
    [Authorize(Policy = "touristPolicy")]

    public class ProblemController : BaseApiController
    {
        private readonly IProblemService _problemService;
        private readonly ITourService _tourService;
        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
        }
        [HttpPost]
        public ActionResult<ProblemDto> Create([FromBody] ProblemDto problem)
        {
            var result = _problemService.Create(problem);
            return CreateResponse(result);
        }
        [HttpPatch("/{tourId:int}/addProblem")]
        public ActionResult<TourDto> AddProblem(int tourId, [FromBody] ProblemDto problem)
        {

            var result = _problemService.Create(problem);
            var result2 = _tourService.AddProblem(tourId, problem);
            return CreateResponse(result);
        }
    }
    
}
