using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour.DataIn;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class TourService : CrudService<TourIn,Tour>, ITourService
    {
        public TourService(ICrudRepository<Tour> repository, IMapper mapper) : base(repository, mapper) { }

      
    }
}
