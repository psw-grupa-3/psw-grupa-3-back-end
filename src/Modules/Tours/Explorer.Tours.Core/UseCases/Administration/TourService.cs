using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.Core.Domain.Users;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Converters;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Administration
{
    public class TourService : CrudService<TourDto,Tour>, ITourService
    {
        private readonly ICrudRepository<TourExecution> _tourExecutionRepository;
        public TourService(ICrudRepository<Tour> repository, ICrudRepository<TourExecution> tourExecutionRepository, IMapper mapper) : base(repository, mapper) 
        {
            _tourExecutionRepository = tourExecutionRepository;
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

            bool hasReviewWithUserId = tour.Reviews.Any(r => r.TouristId == review.TouristId);

            var sortedTourExecutions = _tourExecutionRepository.GetPaged(0, 0).Results.Where(te => te.TourId == tourId).OrderByDescending(te => te.Id).ToList();

            TourExecution tourExecution = sortedTourExecutions.FirstOrDefault();
            if (tourExecution == null) return Result.Fail("You must start the tour.");

            double percentageOfDone = tourExecution.PercentageOfDone(tourExecution);
            bool isLastActivityBad=tourExecution.IsLastActivityWithinWeek(tourExecution);
            if (percentageOfDone > 35.0 && !isLastActivityBad )
            {
                if (!hasReviewWithUserId) {
                    tour.Reviews.Add(tourReview);
                    CrudRepository.Update(tour);

                    return MapToDto(tour); }
                else return Result.Fail("You already gave a review.");
            }

            return Result.Fail("You must complete more than 35% of tour in the last 7 days.");

        }

        public Result<double> GetAverageRating(int tourId)
        {
            Tour tour = CrudRepository.Get(tourId);
            return tour.GetAverageRating();
        }

    }
}
