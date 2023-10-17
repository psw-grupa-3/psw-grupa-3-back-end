using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;

namespace Explorer.Stakeholders.API.Public;

public interface IClubInvitationService
{
   
    Result<ClubInvitationDto> Create(ClubInvitationDto clubInvitation);
 
    //Result<ClubInvitationDto> UpdateEntity(int id,ClubInvitationDto clubInvitation);
    //Result Delete(int id);
}