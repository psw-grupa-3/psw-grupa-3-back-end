using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain.Users;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class UserService : BaseService<UserDto, User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository) : base(mapper)
        {
            _userRepository = userRepository;
        }

        public Result Block(string username)
        {
            try
            {
                _userRepository.Block(username);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error blocking the user: {ex.Message}");
            }
        }

        public Result<List<UserDto>> GetAll()
        {
            var users = _userRepository.GetAll();
            users.ForEach(u => u.HashPassword());
            return MapToDto(users);
        }
    }
}
