using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;

namespace Explorer.API.Controllers.Tourist
{
    [Route("api/tourist/problem")]
    [Authorize(Policy = "touristPolicy")]

    public class ProblemController : BaseApiController
    {
        private readonly IProblemService _problemService;
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
    }
    
}
