using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.UseCasesEvents
{
    public class StartTour: CrudService<TourExecutionDto, TourExecution>
    {
        private readonly ICrudRepository<Tour> _tourRepository;
        private DateTime _clock;

        public StartTour(ICrudRepository<Tour> tourRepository, ICrudRepository<TourExecution> repository, DateTime clock, IMapper mapper) : base(repository, mapper)
        {
            _tourRepository = tourRepository;
            _clock = clock;
        }

        public void Execute(int tourId)
        {
            try
            {
                var tour = _tourRepository.Get(tourId);
                var tourExecution = new TourExecution(tour.Points, tourId);
                CrudRepository.Create(tourExecution);
                //cuvanje eventa
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
