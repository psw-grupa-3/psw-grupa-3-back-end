namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IPersonRepository
    {
        List<Person> GetAll(List<string> usernames);
    }
}
