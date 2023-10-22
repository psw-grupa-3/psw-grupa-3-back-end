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
    public class ClubService : CrudService<ClubRegistrationDto, Club>, IClubService
    {
        
        public ClubService(ICrudRepository<Club> repository, IMapper mapper) : base(repository, mapper) {
            //crudRepository = repository;
        }

        /*public Result<ClubRegistrationDto> UpdateEntity(int id, ClubRegistrationDto updatedData)
        {
            // Ažuriranje postojećeg entiteta sa novim podacima
            Club club = new Club
            {
                Name = updatedData.Name,
                Description = updatedData.Description,
                URL = updatedData.URL,
            };

            crudRepository.Update(club);
            return Result.Ok();
        }*/

        
        public ClubRegistrationDto MemberExist(ClubRegistrationDto club,int id) {
          
                club.MembersId.Remove(id);
            
            return club;
        }




        public bool IsClubOwner(int userId,int clubId)
        {

            Result<PagedResult<ClubRegistrationDto>> allClubsResult = GetPaged(1, int.MaxValue);

            if (allClubsResult.IsSuccess)
            {

                var allClubs = allClubsResult.Value.Results;
                
                return allClubs.Any(club => club.OwnerId == userId && club.Id==clubId);
            }
            return false;
        }


    }
}
