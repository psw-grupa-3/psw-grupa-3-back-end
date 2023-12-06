using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private readonly StakeholdersContext _dbContext;

        public PersonRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Person> GetAll(List<string> usernames)
        {
            var userIds = _dbContext.Users.Where(u => usernames.Any(username => username.Equals(u.Username)))
                .Select(user => user.Id).Distinct();
            return _dbContext.People.Where(p => userIds.Any(u => u.Equals(p.UserId))).ToList();
        }
    }
}
