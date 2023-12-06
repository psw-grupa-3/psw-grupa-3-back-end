using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Infrastructure.Database;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static Explorer.Payments.API.Enums.TourPurchaseTokenEnums;

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
            var retVal = new List<TourPurchaseToken>();
            foreach(var item in shoppingCart.Items)
            {
                var tokenType = TourPurchaseTokenType.SingleTour;
                if (item.Type.Equals("Bundle")) tokenType = TourPurchaseTokenType.Bundle;

                var token = new TourPurchaseToken(0, shoppingCart.IdUser, item.IdType, DateTime.Now.ToUniversalTime(), item.Name, item.Image, tokenType);
                _dbSet.Add(token);
                retVal.Add(token);
            }
            DbContext.SaveChanges();

            return retVal;
        }
        public Result<bool> GetToken(int idUser, int IdType)
        {
            foreach(var token in _dbSet)
            {
                if(token.TypeId == IdType && token.UserId == idUser)
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
