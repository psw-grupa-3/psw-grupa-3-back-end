using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;


namespace Explorer.Tours.API.Public;

public interface IObjectService
{
    Result<PagedResult<ObjectDto>> GetPaged(int page, int pageSize);
    Result<ObjectDto> Create(ObjectDto objectDto);
    Result<ObjectDto> Update(ObjectDto objectDto);
    Result Delete(int id);


}

