using FluentResults;

namespace Explorer.Stakeholders.API.Internal
{
    public interface IInternalProfileService
    {
        Result RewardWithXp(List<string> usernames);
    }
}
