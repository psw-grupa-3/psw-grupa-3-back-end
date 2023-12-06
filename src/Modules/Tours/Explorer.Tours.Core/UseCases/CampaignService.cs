using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using FluentResults;

namespace Explorer.Tours.Core.UseCases;
public class CampaignService : CrudService<CampaignDto, Campaign>, ICampaignService
{
    private readonly ICrudRepository<Campaign> _campaignRepository;
    public CampaignService(ICrudRepository<Campaign> repository, IMapper mapper) : base(repository, mapper)
    {
        _campaignRepository = repository;
    }
}

