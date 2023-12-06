namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    public interface IProfileRepository
    {
        List<Person> GetAll(List<string> usernames);
    }
}
