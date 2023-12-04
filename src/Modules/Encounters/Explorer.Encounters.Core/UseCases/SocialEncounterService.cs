using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Explorer.Encounters.Core.Domain.SolvingStrategies;
using FluentResults;

namespace Explorer.Encounters.Core.UseCases
{
    public class SocialEncounterService: BaseService<SocialEncounterDto, SocialEncounter>, ISocialEncounterService
    {
        private readonly ISocialEncounterRepository _repository;

        public SocialEncounterService(IMapper mapper, ISocialEncounterRepository repository) : base(mapper)
        {
            _repository = repository;
        }

        public Result<SocialEncounterDto> Get(int id)
        {
            var encounter = _repository.Get(id);
            return MapToDto(encounter);
        }

        public Result<List<SocialEncounterDto>> GetAll()
        {
            var encounters = _repository.GetAll();
            return MapToDto(encounters);
        }

        public Result<SocialEncounterDto> Create(SocialEncounterDto socialEncounter)
        {
            var result = _repository.Create(MapToDomain(socialEncounter));
            return MapToDto(result);
        }

        public Result<SocialEncounterDto> Update(SocialEncounterDto socialEncounter)
        {
            try
            {
                var result = _repository.Update(MapToDomain(socialEncounter));
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
        }

        public Result<SocialEncounterDto> Solve(int id, ParticipantLocationDto participantLocation)
        {
            var encounter = _repository.Get(id);
            encounter.Solve(participantLocation.Username, participantLocation.Longitude, participantLocation.Latitude);
            return MapToDto(encounter);
        }
    }
}
