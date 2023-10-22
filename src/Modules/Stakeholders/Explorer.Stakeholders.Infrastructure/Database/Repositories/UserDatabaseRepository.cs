using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Stakeholders.Infrastructure.Database.Repositories
{
    public class UserDatabaseRepository : IUserRepository
    {
        private readonly StakeholdersContext _dbContext;

        public UserDatabaseRepository(StakeholdersContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Exists(string username)
        {
            return _dbContext.Users.Any(user => user.Username == username);
        }

        public User? GetActiveByName(string username)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Username == username && user.IsActive);
        }

        public User Create(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public long GetPersonId(long userId)
        {
            var person = _dbContext.People.FirstOrDefault(p => p.UserId == userId);
            if (person == null)
            {
                throw new KeyNotFoundException("Person not found.");
            }
            return person.Id;
        }

        public List<UserAdminDto> GetAll()
        {
            var users = _dbContext.Users.ToList();
            var userAndPersonDtos = new List<UserAdminDto>();

            foreach (var user in users)
            {
                var personId = _dbContext.People.FirstOrDefault(p => p.UserId == user.Id)?.Id;
                if (personId != null)
                {
                    var person = _dbContext.People.FirstOrDefault(p => p.Id == personId);
                    var userAndPersonDto = new UserAdminDto
                    {
                        Username = user.Username,
                        Email = person?.Email,
                        Role = user.GetPrimaryRoleName(),
                        IsActive = user.IsActive
                    };
                    userAndPersonDtos.Add(userAndPersonDto);
                }
            }

            return userAndPersonDtos;
        }



        public void Block(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found.");
            }

            user.IsActive = false;
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }


        public Person GetPersonById(long personId)
        {
            return _dbContext.People.FirstOrDefault(p => p.Id == personId);
        }
    }
}
