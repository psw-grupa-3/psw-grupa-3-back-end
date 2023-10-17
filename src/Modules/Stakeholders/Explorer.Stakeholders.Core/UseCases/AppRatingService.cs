using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases;

public class AppRatingService : CrudService<AppRatingDto, AppRating>, IAppRatingService
{
    public AppRatingService(ICrudRepository<AppRating> repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public bool HasUserRated(int userId)
    {
        // Get all app ratings
        Result<PagedResult<AppRatingDto>> allRatingsResult = GetPaged(1, int.MaxValue);

        // Check if there is any rating by the specified user
        if (allRatingsResult.IsSuccess)
        {
            var allRatings = allRatingsResult.Value.Results;
            return allRatings.Any(rating => rating.UserId == userId);
        }

        // Handle the case where there was an issue with retrieving the ratings.
        // For example, you might log an error or throw an exception, depending on your application's error handling strategy.

        // If there's an error, you may want to return false by default or handle it differently.
        return false;
    }


}
