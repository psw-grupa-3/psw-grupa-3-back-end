using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain.Users;
using Explorer.Stakeholders.Core.UseCases;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author.Tour
{
    [Route("api/author/problems")]
    //[Authorize(Policy = "authorPolicy")]
    public class ProblemController : BaseApiController
    {
        private readonly IProblemService _problemService;
        private readonly IUserNotificationService _userNotificationService;
        public ProblemController(IProblemService problemService, IUserNotificationService userNotificationService)
        {
            _problemService = problemService;
            _userNotificationService = userNotificationService;
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

        [HttpPatch("respondToProblem/{id}/{response}")]
        public ActionResult<PagedResult<ProblemDto>> RespondToProblem(long id, string response)
        {
            var result = _problemService.RespondToProblem(id, response);
            var problem = result.Value;
            return Ok(result);
        }

        [HttpGet("getToursProblems/{id}")]
        public ActionResult<PagedResult<ProblemDto>> GetToursProblems(long id)
        {
            var result = _problemService.GetToursProblems(id);

            return Ok(result);
        }
    }
}

