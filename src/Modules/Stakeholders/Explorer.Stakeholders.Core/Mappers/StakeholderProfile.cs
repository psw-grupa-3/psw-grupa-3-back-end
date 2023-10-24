using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;

namespace Explorer.Stakeholders.Core.Mappers;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {

        CreateMap<UserAdminDto, User>().ReverseMap();

        CreateMap<AppRatingDto, AppRating>().ReverseMap();
        CreateMap<ClubRegistrationDto, Club>().ReverseMap();
        CreateMap<ClubInvitationDto, ClubInvitation>().ReverseMap();
        CreateMap<MembershipRequestDto, MembershipRequest>().ReverseMap();

    }
}