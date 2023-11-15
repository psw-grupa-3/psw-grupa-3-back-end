using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.API.Public;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Converters;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class ProblemService : CrudService<ProblemDto, Problem>, IProblemService
    {
        private readonly IProblemRepository _problemRepository;

        public ProblemService(ICrudRepository<Problem> repository, IMapper mapper, IProblemRepository problemRepository) : base(repository, mapper)
        {
            _problemRepository = problemRepository;
        }



        public Result<List<ProblemDto>> GetProblemsWithExpiredDeadline(List<ProblemDto> problems)
        {
            var unresolvedProblems = _problemRepository.GetUnresolvedProblemsWithDeadline(problems);

            return Result.Ok(unresolvedProblems);



        }
        public Result<List<ProblemDto>> GetAll()
        {
            var problems = _problemRepository.GetAll();

            if (problems != null)
            {

                return Result.Ok(problems);
            }
            else
            {
                return Result.Fail<List<ProblemDto>>("Failed to retrieve problems.");
            }
        }

        public Result<ProblemDto> RespondToProblem(long id, string response)
        {
            var problemDto = _problemRepository.GetProblemById(id);
            var problem = ProblemConverter.ToDomain(problemDto);
            problem.RespondToProblem(response);
            var count = _problemRepository.GetProblemCount();
            var problemDto2 = ProblemConverter.ToDto(problem);
            problemDto2.Id = (long)count + 1;
            var problem2 = ProblemConverter.ToDomain(problemDto2);
            CrudRepository.Delete(problem.Id);
            CrudRepository.Create(problem2);
            _problemRepository.SaveChanges(problem);
            problemDto = ProblemConverter.ToDto(problem);
            problemDto.Id = problem.Id;
            return problemDto;
        }

        public object ProblemNotSolved(long id, string comment)
        {
            var problemDto = _problemRepository.GetProblemById(id);
            var problem = ProblemConverter.ToDomain(problemDto);
            problem.LeaveUnsolvedComment(comment);
            var count = _problemRepository.GetProblemCount();
            var problemDto2 = ProblemConverter.ToDto(problem);
            problemDto2.Id = (long)count + 1;
            var problem2 = ProblemConverter.ToDomain(problemDto2);
            CrudRepository.Delete(problem.Id);
            CrudRepository.Create(problem2);
            _problemRepository.SaveChanges(problem);
            problemDto = ProblemConverter.ToDto(problem);
            problemDto.Id = problem.Id;
            return problemDto;
        }

        public object ProblemIsSolved(long id)
        {
            var problemDto = _problemRepository.GetProblemById(id);
            var problem = ProblemConverter.ToDomain(problemDto);
            problem.SolveProblem();
            var count = _problemRepository.GetProblemCount();
            var problemDto2 = ProblemConverter.ToDto(problem);
            problemDto2.Id = (long)count + 1;
            var problem2 = ProblemConverter.ToDomain(problemDto2);
            CrudRepository.Delete(problem.Id);
            CrudRepository.Create(problem2);
            _problemRepository.SaveChanges(problem2);
            problemDto = ProblemConverter.ToDto(problem2);
            problemDto.Id = problem.Id;
            return problemDto;
        }

        public object GetProblemById(long id)
        {
            var problemDto = _problemRepository.GetProblemById(id);
            return problemDto;
        }

        public object GetToursProblems(long id)
        {
            var problems = _problemRepository.GetToursProblems(id);
            return problems;
        }
    }
}