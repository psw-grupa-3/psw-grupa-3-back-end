using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Shopping
{
    public class TourPurchaseTokenService : CrudService<TourPurchaseTokenDto, TourPurchaseToken>, ITourPurchaseTokenService
    {
        private readonly ITourPurchaseTokenRepository _tourPurchaseRepository;
        public TourPurchaseTokenService(ICrudRepository<TourPurchaseToken> repository, IMapper mapper, ITourPurchaseTokenRepository tourPurchaseRepository) : base(repository, mapper)
        {
            _tourPurchaseRepository = tourPurchaseRepository;
        }

        public Result<List<TourPurchaseTokenDto>> PurchaseItemsFromCart(ShoppingCartDto shoppingCart)
        {
            return MapToDto(_tourPurchaseRepository.PurchaseItemsFromCart(shoppingCart));
        }
    }
}
