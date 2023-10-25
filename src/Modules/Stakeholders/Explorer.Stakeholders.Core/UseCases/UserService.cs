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

        public Result Block(string username)
        {
            try
            {
                // Implement service-specific logic to block a user
                userRepository.Block(username);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error blocking the user: {ex.Message}");
            }
        }
        public Result<List<UserAdminDto>> GetAll()
        {
            List<UserAdminDto> users = new();
            foreach(var user in userRepository.GetAll())
            {
                users.Add(new()
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Role = user.Role,
                    IsActive = user.IsActive,
                    Email = user.Email
                }) ;
            }
            return users;
        }



    }
}
