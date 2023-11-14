using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Order;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourPurchaseTokenRepository : CrudDatabaseRepository<TourPurchaseToken, ToursContext>, ITourPurchaseTokenRepository
    {
        private readonly ToursContext _context;
        private readonly DbSet<TourPurchaseToken> _dbSet;
        public TourPurchaseTokenRepository(ToursContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            _dbSet = DbContext.Set<TourPurchaseToken>();
        }

        public Result<List<TourPurchaseToken>> PurchaseItemsFromCart(ShoppingCartDto shoppingCart)
        {
            var retVal = new List<TourPurchaseToken>();
            foreach(var item in shoppingCart.Items)
            {
                var token = new TourPurchaseToken(0, shoppingCart.IdUser, item.IdTour, DateTime.Now.ToUniversalTime(), item.Name);
                _dbSet.Add(token);
                retVal.Add(token);
            }
            DbContext.SaveChanges();

            return retVal;
        }

        public Result<List<TourPurchaseToken>> GetAllForUser(int userId)
        {
            var usersTokens = _dbSet.Where(x => x.UserId == userId).ToList();
            return usersTokens;
        }

    }
}
