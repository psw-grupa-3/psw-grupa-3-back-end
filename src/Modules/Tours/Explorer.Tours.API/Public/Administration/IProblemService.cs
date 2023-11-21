using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.Administration
{
    public interface IProblemService
    {
        Result<ProblemDto> Create(ProblemDto problem); 
        Result<PagedResult<ProblemDto>> GetPaged(int page, int pageSize);
        Result<List<ProblemDto>> GetProblemsWithExpiredDeadline(List<ProblemDto> problems);
        Result<List<ProblemDto>> GetAll();
        Result<ProblemDto> RespondToProblem(long id, string response);
        object ProblemNotSolved(long id, string comment);
        object ProblemIsSolved(long id);
        object GetProblemById(long id);
        object GetToursProblems(long id);
           object SetProblemDeadline(long id, DateTime deadline);
        Result<ProblemDto> DeleteProblem(long id);
    }
}
