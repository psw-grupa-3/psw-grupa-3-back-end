using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public
{
    public interface IClubService
    {
        Result<ClubRegistrationDto> Create(ClubRegistrationDto reg);
        Result<ClubRegistrationDto> Update(ClubRegistrationDto reg);
        //Result<ClubRegistrationDto> UpdateEntity(int id, ClubRegistrationDto reg);

    }
}
