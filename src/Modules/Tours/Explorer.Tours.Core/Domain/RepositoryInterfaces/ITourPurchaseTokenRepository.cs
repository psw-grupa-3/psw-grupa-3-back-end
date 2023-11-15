using Explorer.Tours.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface ITourPurchaseTokenRepository
    {
        Result<List<TourPurchaseToken>> GetAllForUser(int userId);
        Result<List<TourPurchaseToken>> PurchaseItemsFromCart(ShoppingCartDto shoppingCart);
        Result<bool> GetToken(int idUser, int idTour);
    }
}
