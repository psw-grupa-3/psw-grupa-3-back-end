using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Author
{
    [Authorize(Policy = "authorPolicy")]
    [Route("api/author/bundle")]
    public class BundleController : BaseApiController
    {
        private readonly IBundleService _bundleService;

        public BundleController(IBundleService bundleService) 
        { 
            _bundleService = bundleService;
        }

        [HttpPost("create")]
        public ActionResult<BundleDto> Create([FromBody] BundleDto dataIn) 
        { 
            throw new NotImplementedException();
        }
    }
}
