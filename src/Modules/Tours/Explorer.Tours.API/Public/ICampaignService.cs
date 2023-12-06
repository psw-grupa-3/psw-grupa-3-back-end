using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public;
public interface ICampaignService
{
    Result<CampaignDto> Create(CampaignDto campaignDto);
    Result<PagedResult<CampaignDto>> GetPaged(int page, int pageSize);
}

