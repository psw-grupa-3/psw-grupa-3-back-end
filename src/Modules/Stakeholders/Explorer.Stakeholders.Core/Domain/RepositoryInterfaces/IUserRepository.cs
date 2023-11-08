using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain.Users;

namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool Exists(string username);
        User? GetActiveByName(string username);
        User Create(User user);
        long GetPersonId(long userId);
        void Block(string username);
        List<UserPerson> GetAll();
        Person GetPersonById(long personId);
    }
}
