using Explorer.BuildingBlocks.Core.UseCases;
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
        public ProblemController(IProblemService problemService)
        {
            _problemService = problemService;
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
            return Ok(result);
        }
    }
}
