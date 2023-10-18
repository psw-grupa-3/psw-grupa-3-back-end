using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
   
    public class MembershipRequestDatabaseRepository : IMembershipRequestRepository
    {
        private readonly StakeholdersContext _dbContext;

        public MembershipRequestDatabaseRepository (StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MembershipRequest Create(MembershipRequest request)
        {
            _dbContext.MembershipRequests.Add(request);
            _dbContext.SaveChanges();
            return request;
        }
    }
}
