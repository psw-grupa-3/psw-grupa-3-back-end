using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Explorer.API.Controllers.Tourist;
[Route("api/tourist/campaign")]
public class CampaignController : BaseApiController
{
    private readonly ICampaignService _campaignService;
    public CampaignController(ICampaignService campaignService) 
    {
        _campaignService = campaignService;
    }

    [HttpPost]
    public ActionResult<CampaignDto> Create([FromBody] CampaignDto dto)
    {
        throw new NotImplementedException();
    }
}