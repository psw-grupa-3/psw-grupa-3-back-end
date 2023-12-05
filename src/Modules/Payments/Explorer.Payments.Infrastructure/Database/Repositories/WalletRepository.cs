using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.Order;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Payments.Infrastructure.Database.Repositories
{
    public class WalletRepository : CrudDatabaseRepository<Wallet, PaymentsContext>, IWalletRepository
    {
        private readonly PaymentsContext _context;
        private readonly DbSet<Wallet> _dbSet;
            public WalletRepository(PaymentsContext dbContext) : base(dbContext)
            {
                _context = dbContext;
                _dbSet = DbContext.Set<Wallet>();
            }

        public Result<Wallet> CreateWallet(int userId)
        {
            var wallet = new Wallet(userId, 0);
            _dbSet.Add(wallet);
            _context.SaveChanges();
            return _dbSet.FirstOrDefault(x => x.UserId == userId);
        }
    }
}
