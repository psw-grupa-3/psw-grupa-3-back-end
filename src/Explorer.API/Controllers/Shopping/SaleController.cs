using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Shopping
{
    [Route("api/author/sale")]
    public class SaleController : BaseApiController
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [Authorize(Policy = "authorPolicy")]
        [HttpPost]
        public ActionResult<SaleDto> Create([FromBody] SaleDto sale)
        {
            var result = _saleService.Create(sale);
            return CreateResponse(result);
        }
    }
}
