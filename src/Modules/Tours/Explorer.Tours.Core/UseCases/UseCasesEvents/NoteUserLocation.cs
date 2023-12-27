using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.Core.Converters;
using Explorer.Tours.Core.Domain.TourExecutions;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.UseCasesEvents
{
    public class NoteUserLocation: CrudService<TourExecutionDto, TourExecution>
    {
        private DateTime _clock;

        public NoteUserLocation(ICrudRepository<TourExecution> repository, DateTime clock, IMapper mapper) : base(repository, mapper)
        {
            _clock = clock;
        }

        public void Execute(int executionId, PositionDto position)
        {
            try
            {
                var positionDomain = PositionConverter.ToDomain(position);
                var execution = CrudRepository.Get(executionId);
                execution.UpdatePositionEvent(executionId, positionDomain, _clock);
                CrudRepository.Update(execution);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
