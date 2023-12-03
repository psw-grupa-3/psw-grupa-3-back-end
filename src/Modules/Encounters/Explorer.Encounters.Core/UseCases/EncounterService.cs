using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using FluentResults;

namespace Explorer.Encounters.Core.UseCases
{
    public class EncounterService: CrudService<EncounterDto, Encounter>, IEncounterService
    {
        public EncounterService(ICrudRepository<Encounter> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }

        public Result<EncounterDto> Activate(int id, PersonLocationDto personLocation)
        {
            var encounter = CrudRepository.Get(id);
            var result = encounter.Activate((int)personLocation.PersonId, personLocation.Longitude, personLocation.Latitude);
            return MapToDto(encounter);
        }
    }
}
