using AutoMapper;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.Core.Domain;
using Object = Explorer.Tours.Core.Domain.Object;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.Bundles;

namespace Explorer.Tours.Core.Mappers;

public class ToursProfile : Profile
{
    public ToursProfile()
    {
        
        CreateMap<EquipmentDto, Equipment>().ReverseMap();
        CreateMap<ProblemDto, Problem>().ReverseMap();
        CreateMap<TouristEquipmentDto, TouristEquipment>().ReverseMap();
        CreateMap<PreferenceDto, Preference>().ReverseMap();
        CreateMap<TourDto, Tour>().ReverseMap();
        CreateMap<CampaignDto, Campaign>().ReverseMap();
        CreateMap<PointDto, Point>().ReverseMap();
        CreateMap<RequiredTimeDto, RequiredTime>().ReverseMap();
        CreateMap<TagDto, Tag>().ReverseMap();
        CreateMap<GuideDto, Guide>().ReverseMap();
        CreateMap<TourReviewDto, TourReview>().ReverseMap();
        CreateMap<EquipmentManagmentDto, EquipmentManagment>().ReverseMap();
        CreateMap<ObjectDto, Object>().ReverseMap();
        CreateMap<TouristPositionDto, TouristPosition>().ReverseMap();
        CreateMap<PublicRegistrationRequestDto, PublicRegistrationRequest>().ReverseMap();
        CreateMap<BundleDto, Bundle>().ReverseMap();


        //CreateMap<TourDto, Tour>()
        //    .ForMember(dest => dest.Problems, opt =>
        //        opt.MapFrom(src =>
        //            src.Problems.Select(x =>
        //                new Problem(x.Id, x.Category, x.Priority, x.Description, x.Time, x.TourId, x.TouristId, x.AuthorsSolution, x.IsSolved, x.UnsolvedProblemComment, x.Deadline)
        //                )));

        //CreateMap<Tour, TourDto>()
        //    .ForMember(dest => dest.Problems, opt =>
        //        opt.MapFrom(src =>
        //            src.Problems.Select(x =>
        //                new ProblemDto
        //                {
        //                    Category = x.Category,
        //                    Priority = x.Priority,
        //                    Description = x.Description,
        //                    Time = x.Time,
        //                    TourId = (int)x.TourId,
        //                    TouristId = (int)x.TouristId,
        //                    AuthorsSolution = x.AuthorsSolution,
        //                    IsSolved = x.IsSolved,
        //                    UnsolvedProblemComment = x.UnsolvedProblemComment,
        //                    Deadline = x.Deadline
        //                }
        //            )));
    }
}