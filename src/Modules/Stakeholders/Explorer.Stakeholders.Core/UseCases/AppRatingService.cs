using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;

namespace Explorer.Stakeholders.Core.UseCases;

public class AppRatingService : CrudService<AppRatingDto, AppRating>, IAppRatingService
{
    public AppRatingService(ICrudRepository<AppRating> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
