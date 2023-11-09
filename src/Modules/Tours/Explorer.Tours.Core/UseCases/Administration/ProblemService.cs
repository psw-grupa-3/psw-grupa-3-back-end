using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class ProblemService : CrudService<ProblemDto, Problem>, IProblemService
    {
        public ProblemService(ICrudRepository<Problem> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
