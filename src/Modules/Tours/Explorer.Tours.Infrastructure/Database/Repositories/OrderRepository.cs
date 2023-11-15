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

        public Result<ShoppingCart> AddToCart(OrderItem orderItem, int userId)
        {
            var cart = _dbSet.Where(x => x.IdUser ==  userId).FirstOrDefault();
            if(cart == null)
            {
                var orderItems = new List<OrderItem> { orderItem };
                var newCart = new ShoppingCart(userId, orderItems);
                _dbSet.Add(newCart);
                DbContext.SaveChanges();
                return newCart;
            }
            cart.Items.Add(orderItem);
            DbContext.Update(cart);
            DbContext.SaveChanges();
            return cart;
        }

        public Result<ShoppingCartDto>? GetByUserId(int id)
        {
            var cart = _dbSet.Where(i => i.IdUser == id).FirstOrDefault();

            if(cart == null)
            {
                throw new KeyNotFoundException("Not found: " + id);
            }
            List<OrderItemDto> list = new List<OrderItemDto>();
            foreach(var item in cart.Items)
            {
                OrderItemDto itemDto = new OrderItemDto
                {
                    IdTour = item.IdTour,
                    Name = item.Name,
                    Price = item.Price,
                    Image = item.Image,
                };
                list.Add(itemDto);
            }
            ShoppingCartDto result = new ShoppingCartDto
            {
                Id = cart.Id,
                IdUser = cart.IdUser,
                Items = list,
            };
            return result;
        }
    }
}
