using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain.Order;
using FluentResults;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface IOrderRepository : ICrudRepository<ShoppingCart>
    {
        Result<ShoppingCart> AddToCart(OrderItem orderItem, int userId);
        Result<ShoppingCartDto>? GetByUserId(int id);

    }
}
