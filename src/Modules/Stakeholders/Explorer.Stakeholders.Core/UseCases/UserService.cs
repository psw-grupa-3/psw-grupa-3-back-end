using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using System;
using System.Collections.Generic;
using Explorer.Stakeholders.API.Public;


namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserService : BaseService<UserAdminDto, User>, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
            : base(mapper)
        {
            this.userRepository = userRepository;
        }

        public Result<UserAdminDto> Update(UserAdminDto user)
        {
            // Implement service-specific logic to update a user
            var userEntity = MapToDomain(user);
            // Perform the update operation on userEntity
            return MapToDto(userEntity);
        }

        public Result Block(long userId)
        {
            try
            {
                // Implement service-specific logic to block a user
                userRepository.Block(userId);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error blocking the user: {ex.Message}");
            }
        }

        public Result<IEnumerable<UserAdminDto>> GetAll()
        {
            try
            {
                // Implement service-specific logic to get all users
                var users = userRepository.GetAll();
                var userAdminDtos = users.Select(user =>
                {
                    var userDto = MapToDto(user);
                    userDto.Role = user.GetPrimaryRoleName(); // Convert UserRole to a string
                    return userDto;
                });
                return Result.Ok(userAdminDtos);
            }
            catch (Exception ex)
            {
                return Result.Fail<IEnumerable<UserAdminDto>>($"Error getting all users: {ex.Message}");
            }
        }


    }
}
