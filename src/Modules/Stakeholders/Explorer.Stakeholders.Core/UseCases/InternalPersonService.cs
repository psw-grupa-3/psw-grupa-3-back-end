using Explorer.Stakeholders.API.Internal;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class InternalPersonService: IInternalPersonService
    {
        private readonly IPersonRepository _profileRepository;

        public InternalPersonService(IPersonRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public Result RewardWithXp(List<string> usernames)
        {
            throw new NotImplementedException();
        }
    }
}
