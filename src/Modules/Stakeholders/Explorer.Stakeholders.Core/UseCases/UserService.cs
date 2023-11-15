using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain.Users;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserService : BaseService<UserAdminDto, User>, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            this.userRepository = userRepository;
        }

        public Result<UserAdminDto> Update(UserAdminDto user)
        {
            var userEntity = MapToDomain(user);
            return MapToDto(userEntity);
        }

        public Result Block(string username)
        {
            try
            {
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
            foreach (var user in userRepository.GetAll())
            {
                users.Add(new()
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Role = user.Role,
                    IsActive = user.IsActive,
                    Email = user.Email
                });
            }
            return users;
        }

    }
}
