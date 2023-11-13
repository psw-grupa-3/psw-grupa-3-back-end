﻿using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Converters;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.UseCases
{
    public class TourExecutionService: CrudService<TourExecutionDto, TourExecution>, ITourExecutionService
    {
        private readonly ICrudRepository<Tour> _tourRepository;
        public TourExecutionService(ICrudRepository<TourExecution> repository, ICrudRepository<Tour> tourRepository, IMapper mapper) : base(repository, mapper)
        {
            _tourRepository = tourRepository;
        }
        public Result<TourExecutionDto> QuitExecution(int executionId)
        {
            var execution = CrudRepository.Get(executionId);
            execution.QuitTourExecution();
            CrudRepository.Update(execution);
            return MapToDto(execution);
        }
        public Result<TourExecutionDto> UpdatePosition(int executionId, PositionDto position)
        {
            var positionDomain = PositionConverter.ToDomain(position);
            var execution = CrudRepository.Get(executionId);
            execution.UpdatePosition(positionDomain);
            CrudRepository.Update(execution);
            return MapToDto(execution);
        }
        public Result<TourExecutionDto> StartExecution(int tourId)
        {
            var tour = _tourRepository.Get(tourId);
            var tourExecution = new TourExecution(tour.Points);
            CrudRepository.Create(tourExecution);
            return MapToDto(tourExecution);
        }
    }
}