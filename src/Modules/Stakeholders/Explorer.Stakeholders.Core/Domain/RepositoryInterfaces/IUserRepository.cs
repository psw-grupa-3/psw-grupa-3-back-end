namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        bool Exists(string username);
        User? GetActiveByName(string username);
        User Create(User user);
        long GetPersonId(long userId);
        void Block(long userId); // Add Block method
        List<User> GetAll(); // Add GetAll method
    }
}
