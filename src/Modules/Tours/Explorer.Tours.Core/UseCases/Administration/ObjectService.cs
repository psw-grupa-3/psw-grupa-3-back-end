using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class ObjectService : CrudService<ObjectDto, Domain.Object>, IObjectService
    {
        public ObjectService(ICrudRepository<Domain.Object> repository, IMapper mapper) : base(repository, mapper) { }
    }
}
