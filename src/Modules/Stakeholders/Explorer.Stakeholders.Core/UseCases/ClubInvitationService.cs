using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Stakeholders.Core.UseCases;
using FluentResults;

namespace Explorer.Stakeholders.Core.UseCases
{
    public class ClubInvitationService : CrudService<ClubInvitationDto, ClubInvitation>, IClubInvitationService
    {
        public ClubInvitationService(ICrudRepository<ClubInvitation> repository, IMapper mapper) : base(repository, mapper)
        {
            //crudRepository = repository;
        }
/*
        public Result<ClubInvitationDto> UpdateEntity(int id, ClubInvitationDto updatedData)
        {
            // Ažuriranje postojećeg entiteta sa novim podacima
            ClubInvitation clubInvitation = new ClubInvitation
            {
                TouristId = updatedData.TouristId,
                ClubId = updatedData.ClubId,
                IsRead = updatedData.IsRead,
            };

            crudRepository.Update(clubInvitation);
            return Result.Ok();
           
        }
*/
    }
}
