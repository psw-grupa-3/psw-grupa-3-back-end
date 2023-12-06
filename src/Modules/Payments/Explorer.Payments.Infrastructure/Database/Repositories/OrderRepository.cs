using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain.Order;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Infrastructure.Database;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class OrderRepository : CrudDatabaseRepository<ShoppingCart, PaymentsContext>, IOrderRepository
    {
        private readonly PaymentsContext _context;
        private readonly DbSet<ShoppingCart> _dbSet;
        public OrderRepository(PaymentsContext dbContext) : base(dbContext) 
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

        public Result<ShoppingCart>? GetByUserId(int userId)
        {
            var cart = _dbSet.Where(i => i.IdUser == userId).FirstOrDefault();

            if(cart == null)
            {
                var orderItems = new List<OrderItem>();
                var newCart = new ShoppingCart(userId, orderItems);
                _dbSet.Add(newCart);
                DbContext.SaveChanges();
                return newCart;
            }
            return cart;
        }
    }
}
