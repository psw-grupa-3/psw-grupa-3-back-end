using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Converters;
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

        public Result<List<TourDto>> GetAllPublic()
        {
            var allTours = CrudRepository.GetPaged(0, 0).Results;
            var toursWithPublicPoints = new List<TourDto>();

            foreach(var tour in allTours)
            {
                var publicPoints = tour.Points.Where(point => point.Public).ToList();

                var tourDto = MapToDto(tour);
                tourDto.Points = publicPoints.Select(PointConverter.ToDto).ToList();    
                toursWithPublicPoints.Add(tourDto);
            }

            return toursWithPublicPoints;
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
        public Result<TourDto> PublishPoint(long id, string pointName)
        {
            var tourDb = CrudRepository.Get(id);
            tourDb.PublishPoint(pointName);
            CrudRepository.Update(tourDb);
            return MapToDto(tourDb);
        }
        public Result<TourDto> RateTour(int tourId, TourReviewDto review)
        {
            var tourReview = TourReviewConverter.ToDomain(review);
            Tour tour = CrudRepository.Get(tourId);
            tour.Reviews.Add(tourReview);
            CrudRepository.Update(tour);
            return MapToDto(tour);
        }

        public Result<double> GetAverageRating(int tourId)
        {
            Tour tour = CrudRepository.Get(tourId);
            return tour.GetAverageRating();
        }

    }
}
