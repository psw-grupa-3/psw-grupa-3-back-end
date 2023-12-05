using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.API.Public.Shopping;
using Explorer.Payments.Core.UseCases.Shopping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Shopping
{
    //[Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/wallet")]
    public class WalletController : BaseApiController
    {
        private readonly IWalletService _walletService;
        public WalletController(IWalletService orderService)
        {
            _walletService = orderService;
        }

        [HttpPost]
        public ActionResult<ShoppingCartDto> Create([FromBody] WalletDto wallet)
        {
            var result = _walletService.Create(wallet);
            return CreateResponse(result);
        }

        public ActionResult<WalletDto> CreateWallet(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
