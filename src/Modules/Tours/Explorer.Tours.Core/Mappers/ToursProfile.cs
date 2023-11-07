using AutoMapper;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Tours;
using Explorer.Tours.Core.Domain;
using Object = Explorer.Tours.Core.Domain.Object;
using Explorer.Tours.Core.Domain.Tours;

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
        CreateMap<PointDto, Point>().ReverseMap();
        CreateMap<RequiredTimeDto, RequiredTime>().ReverseMap();
        CreateMap<TagDto, Tag>().ReverseMap();
        CreateMap<GuideDto, Guide>().ReverseMap();
        CreateMap<TourReviewDto, TourReview>().ReverseMap();
        CreateMap<EquipmentManagmentDto, EquipmentManagment>().ReverseMap();
        CreateMap<ObjectDto, Object>().ReverseMap();
        CreateMap<TouristPositionDto, TouristPosition>().ReverseMap();
    }
}