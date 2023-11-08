using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class TourService : CrudService<TourDto,Tour>, ITourService
    {
        public TourService(ICrudRepository<Tour> repository, IMapper mapper) : base(repository, mapper) 
        {

        }

        public Result<TourDto> PublishTour(long id)
        {
            var tourDb = CrudRepository.Get(id);
            tourDb.PublishTour();
            CrudRepository.Update(tourDb);
            return MapToDto(tourDb);
        }

        public Result<TourDto> ArhiveTour(long id)
        {
            var tourDb = CrudRepository.Get(id);
            tourDb.ArhiveTour();
            CrudRepository.Update(tourDb);
            return MapToDto(tourDb);
        }

        public Result<List<TourDto>> SearchByPointDistance(double longitude, double latitude, int distance)
        {
            var searchResults = new List<TourDto>();
            foreach (var tour in CrudRepository.GetPaged(0, 0).Results.Where(x => x.HasPointsWithinDistance(longitude, latitude, distance)))
            {
                searchResults.Add(MapToDto(tour));
            }
            return searchResults;
        }
    }
}
