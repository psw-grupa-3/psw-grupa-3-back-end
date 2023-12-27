using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Core.Domain.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.UseCasesEvents
{
    public class QuitTour: CrudService<TourExecutionDto, TourExecution>
    {
        private DateTime _clock;

        public QuitTour(ICrudRepository<TourExecution> repository, DateTime clock, IMapper mapper) : base(repository, mapper)
        {
            _clock = clock;
        }

        public void Execute(int executionId)
        {
            try
            {
                var execution = CrudRepository.Get(executionId);
                execution.QuitTourEvent(executionId, _clock);
                CrudRepository.Update(execution);
                //cuvanje eventa
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

