using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class InternalProfileService: IInternalProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public InternalProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public Result RewardWithXp(List<string> usernames)
        {
            throw new NotImplementedException();
        }
    }
}
