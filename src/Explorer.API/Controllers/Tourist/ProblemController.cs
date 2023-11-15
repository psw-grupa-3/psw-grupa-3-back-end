using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.UseCases.Administration;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using Newtonsoft.Json;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Stakeholders.API.Public;


namespace Explorer.API.Controllers.Tourist
{
    [Route("api/tourist/problem")]
    //[Authorize(Policy = "touristPolicy")]

    public class ProblemController : BaseApiController
    {
        private readonly IProblemService _problemService;
        private readonly ITourService _tourService;
        private readonly IProblemRepository _problemRepository;

        private readonly IUserNotificationService _userNotificationService;

        public ProblemController(IProblemService problemService, ITourService tourService, IProblemRepository problemRepository, IUserNotificationService userNotificationService)

        {
            _problemService = problemService;
            _tourService = tourService;
            _problemRepository = problemRepository;

            _userNotificationService = userNotificationService;

        }
        [HttpPost]
        public ActionResult<ProblemDto> Create([FromBody] ProblemDto problem)
        {
            var result = _problemService.Create(problem);
            return CreateResponse(result);
        }
        [HttpPatch("addProblem")]
        public ActionResult<TourDto> AddProblem([FromBody] ProblemDto problem)
        {

            int count = _problemRepository.GetProblemCount();


            problem.Id = (long)count+1;

            problem.Id = (long)count + 1;

            problem.Deadline = DateTime.Now.AddDays(5);

            var result = _problemService.Create(problem);
            var result2 = _tourService.AddProblem(problem.TourId, problem);
            return CreateResponse(result);
        }
        [HttpPatch("problemNotSolved/{id}/{comment}")]
        public ActionResult<PagedResult<ProblemDto>> ProblemNotSolved(long id, string comment)
        {
            var result = _problemService.ProblemNotSolved(id, comment);
            return Ok(result);
        }
        [HttpPatch("solveProblem/{id}")]

        public ActionResult<PagedResult<ProblemDto>> SolveProblem(long id)
        

        {
            var result = _problemService.ProblemIsSolved(id);
            return Ok(result);
        }
        [HttpGet("getProblem/{id}")]
        public ActionResult<PagedResult<ProblemDto>> GetProblem(long id)
        {
            var result = _problemService.GetProblemById(id);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public ActionResult<PagedResult<ProblemDto>> GetAll()
        {
            var result = _problemService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            else
            {
                return BadRequest("Failed to retrieve problems.");
            }
        }
    }

}

