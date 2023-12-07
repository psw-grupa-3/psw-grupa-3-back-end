using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Shopping
{
    public class TourPurchaseTokenService : CrudService<TourPurchaseTokenDto, TourPurchaseToken>, ITourPurchaseTokenService
    {
        private readonly ITourPurchaseTokenRepository _tourPurchaseRepository;
        public TourPurchaseTokenService(ICrudRepository<TourPurchaseToken> repository, IMapper mapper, ITourPurchaseTokenRepository tourPurchaseRepository) : base(repository, mapper)
        {
            _tourPurchaseRepository = tourPurchaseRepository;
        }

        public Result<bool> GetToken(int idUser, int idTour)
        {
            return _tourPurchaseRepository.GetToken(idUser, idTour);
        }

        public Result<List<TourPurchaseTokenDto>> PurchaseItemsFromCart(ShoppingCartDto shoppingCart)
        {
            return MapToDto(_tourPurchaseRepository.PurchaseItemsFromCart(shoppingCart));
        }

        public Result<List<TourPurchaseTokenDto>> GetAllForUser(int userId)
        {
            return MapToDto(_tourPurchaseRepository.GetAllForUser(userId));
        }
    }
}
