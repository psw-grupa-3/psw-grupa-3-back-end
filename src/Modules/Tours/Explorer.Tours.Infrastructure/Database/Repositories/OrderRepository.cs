using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.Order;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class OrderRepository : CrudDatabaseRepository<ShoppingCart, ToursContext>, IOrderRepository
    {
        private readonly ToursContext _context;
        private readonly DbSet<ShoppingCart> _dbSet;
        public OrderRepository(ToursContext dbContext) : base(dbContext) 
        {
            _context = dbContext;
            _dbSet = DbContext.Set<ShoppingCart>();
        }
        public Result<ShoppingCartDto> GetByUserId(int id)
        {
            ShoppingCart cart = _dbSet.Where(i => i.IdUser == id).FirstOrDefault();

            if(cart == null)
            {
                return null;
            }
            List<OrderItemDto> list = new List<OrderItemDto>();
            foreach(var item in cart.Items)
            {
                OrderItemDto itemDto = new OrderItemDto
                {
                    IdTour = item.IdTour,
                    Name = item.Name,
                    Price = item.Price
                };
                list.Add(itemDto);
            }
            ShoppingCartDto result = new ShoppingCartDto
            {
                IdUser = cart.IdUser,
                Items = list,
            };
            return result;
        }
    }
}
