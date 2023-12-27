using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Infrastructure.Database;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourPurchaseTokenRepository : CrudDatabaseRepository<TourPurchaseToken, PaymentsContext>, ITourPurchaseTokenRepository
    {
        private readonly PaymentsContext _context;
        private readonly DbSet<TourPurchaseToken> _dbSet;
        public TourPurchaseTokenRepository(PaymentsContext dbContext) : base(dbContext)
        {
            _context = dbContext;
            _dbSet = DbContext.Set<TourPurchaseToken>();
        }

        public Result<List<TourPurchaseToken>> PurchaseItemsFromCart(ShoppingCartDto shoppingCart)
        {
            foreach(var item in shoppingCart.Items)
            {
                if (item.Type.Equals("Bundle"))
                {
                    foreach (var tour in item.ToursInfo)
                    {
                        var token = new TourPurchaseToken(0, shoppingCart.IdUser, tour.Id, DateTime.Now.ToUniversalTime(), tour.Name, tour.Image);
                        _dbSet.Add(token);
                    }
                }
                else
                {
                    var token = new TourPurchaseToken(0, shoppingCart.IdUser, item.IdType, DateTime.Now.ToUniversalTime(), item.Name, item.Image);
                    _dbSet.Add(token);
                }          
            }
            DbContext.SaveChanges();

            return _dbSet.ToList();
        }
        public Result<bool> GetToken(int idUser, int IdTour)
        {
            foreach(var token in _dbSet)
            {
                if(token.TourId == IdTour && token.UserId == idUser)
                {
                    return true;
                }
            }
            return false;
        }

        public Result<List<TourPurchaseToken>> GetAllForUser(int userId)
        {
            var usersTokens = _dbSet.Where(x => x.UserId == userId).ToList();
            return usersTokens;
        }

    }
}
