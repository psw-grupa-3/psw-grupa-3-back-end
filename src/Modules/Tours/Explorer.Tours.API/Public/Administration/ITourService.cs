using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos.Tour.DataIn;
using FluentResults;

namespace Explorer.Tours.API.Public.Administration
{
    public interface ITourService
    {
        Result<PagedResult<TourIn>> GetPaged(int page,  int pageSize);
        Result<TourIn> Create(TourIn dataIn);
        Result<TourIn> Update(TourIn dataIn);
        Result Delete(int id);
    }
}
