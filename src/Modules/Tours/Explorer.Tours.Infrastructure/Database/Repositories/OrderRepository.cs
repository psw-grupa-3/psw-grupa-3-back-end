using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.Order;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class OrderRepository : CrudDatabaseRepository<ShoppingCart, ToursContext>, IOrderRepository
    {

        public OrderRepository(ToursContext dbContext) : base(dbContext)
        {
            
        }
        public ShoppingCart GetById(int id)
        {
            return DbContext.ShoppingCarts.Where(i => i.Id == id).Include(b => b.Items).FirstOrDefault();
        }
    }
}
