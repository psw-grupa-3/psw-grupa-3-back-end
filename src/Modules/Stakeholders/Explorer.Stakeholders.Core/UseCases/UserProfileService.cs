using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserProfileService : CrudService<UserProfileDto, Person>, IUserProfileService
    {
        public UserProfileService(ICrudRepository<Person> repository, IMapper mapper) : base(repository, mapper) { }

        public Result<UserProfileDto> GetPersonByUserId(int id)
        {
            //Trying to get all users
            Result<PagedResult<UserProfileDto>> allUsers = GetPaged(1, int.MaxValue);

            //Cheking if there is any user
            if (allUsers.IsSuccess)
            {
                var userProfiles = allUsers.Value.Results;

                //Finding user by given id
                var userProfile = userProfiles.FirstOrDefault(user => user.UserId == id);

                if (userProfile != null)
                {
                    return Result.Ok(userProfile);
                }
            }

            return Result.Fail<UserProfileDto>(FailureCode.NotFound);

        } 
    }
}
