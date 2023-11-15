using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tours;
using FluentResults;

namespace Explorer.Tours.API.Public.Administration
{
    public interface ITourService
    {
        Result<PagedResult<TourDto>> GetPaged(int page,  int pageSize);
        Result<TourDto> Create(TourDto dataIn);
        Result<TourDto> Update(TourDto dataIn);
        Result Delete(int id);
        Result<TourDto> PublishTour(long id);
        Result<TourDto> ArhiveTour(long id);
        Result<List<TourDto>> SearchByPointDistance(double longitude, double latitude, int distance);
        Result<TourDto> AddProblem(long tourId,ProblemDto problem);
        //Result<TourDto> RespondToProblem(Problem problem);
        //Result<TourDto> UpdateProblem(ProblemDto problem, );
        Result<TourDto> PublishPoint(long id, string pointName);
        Result<TourDto> RateTour(int tourId, TourReviewDto review);
        Result<double> GetAverageRating(int tourId);

        Result<List<TourDto>> GetAllPublic();
    }
}
