using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public.Administration
{
    public interface IPointsService
    {
        Result<PagedResult<PointsDto>> GetPaged(int page, int pageSize);
        Result<PointsDto> Create(PointsDto points);
        Result<PointsDto> Update(PointsDto points);
        Result Delete(int id);
    }
}
