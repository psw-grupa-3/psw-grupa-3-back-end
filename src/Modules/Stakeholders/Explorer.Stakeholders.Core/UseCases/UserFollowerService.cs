using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain.Users;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserFollowerService : CrudService<UserDto, User>, IUserFollowerService
    {
        public UserFollowerService(ICrudRepository<User> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public Result<UserDto> Follow(int userId, int userToFollowId)
        {
            var user = CrudRepository.Get(userId);
            var userToFollow = CrudRepository.Get(userToFollowId);

            if (user is null || userToFollow is null)
            {
                return Result.Fail<UserDto>($"User not found ({FailureCode.NotFound}).");
            }

            try
            { 
                user.AddFollower(userToFollow);
                CrudRepository.Update(user);

                return MapToDto(user);
            }
            catch (Exception ex)
            {
                return Result.Fail<UserDto>(ex.Message);
            }

        }


    }
}