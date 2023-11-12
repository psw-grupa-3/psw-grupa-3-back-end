using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public
{
    public interface IUserProfileService
    {
        Result<PagedResult<UserProfileDto>> GetPaged(int page, int pageSize);
        Result<UserProfileDto> Update(UserProfileDto profile);
        Result<UserProfileDto> Get(int id);
        Result<UserProfileDto> GetPersonByUserId(int id);
    }
}
