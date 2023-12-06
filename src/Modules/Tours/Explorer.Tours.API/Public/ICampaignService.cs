using Explorer.Tours.API.Dtos;
using FluentResults;

namespace Explorer.Tours.API.Public;
public interface ICampaignService
{
    Result<CampaignDto> Create(CampaignDto campaignDto);
    Result Delete(int id);
}

