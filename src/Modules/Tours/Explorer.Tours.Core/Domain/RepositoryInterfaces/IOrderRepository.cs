using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.Order;
using FluentResults;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IOrderRepository : ICrudRepository<ShoppingCart>
    {
        Result<ShoppingCart> AddToCart(OrderItem orderItem, int userId);
        Result<ShoppingCartDto>? GetByUserId(int id);
    }
}
