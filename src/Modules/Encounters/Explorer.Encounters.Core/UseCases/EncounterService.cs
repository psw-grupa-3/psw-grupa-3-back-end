using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;

namespace Explorer.Encounters.Core.UseCases
{
    public class EncounterService: CrudService<EncounterDto, Encounter>, IEncounterService
    {
        public EncounterService(ICrudRepository<Encounter> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }
    }
}
