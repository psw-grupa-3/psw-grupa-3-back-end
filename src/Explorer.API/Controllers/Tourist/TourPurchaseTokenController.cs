﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/tourist/tourPurchaseToken")]
    public class TourPurchaseTokenController : BaseApiController
    {
        private readonly ITourPurchaseTokenService _tokenService;
        public TourPurchaseTokenController(ITourPurchaseTokenService service)
        {
            _tokenService = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<List<TourPurchaseTokenDto>> Create([FromBody] ShoppingCartDto shoppingCart)
        {
            var result = _tokenService.PurchaseItemsFromCart(shoppingCart);
            return CreateResponse(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<PagedResult<TourPurchaseToken>> GetPaged([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _tokenService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }
    }
}