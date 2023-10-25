using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System.Collections.Generic;

namespace Explorer.Stakeholders.API.Public
{
    public interface IUserService
    {
        Result<UserAdminDto> Update(UserAdminDto user);
        Result Block(string username); // Change the return type here
        Result<List<UserAdminDto>> GetAll();
    }
}
