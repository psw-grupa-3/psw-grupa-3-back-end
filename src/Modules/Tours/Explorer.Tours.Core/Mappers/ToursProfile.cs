using AutoMapper;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Dtos.Tour.DataIn;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Order;
using Object = Explorer.Tours.Core.Domain.Object;

namespace Explorer.Tours.Core.Mappers;

public class ToursProfile : Profile
{
    public ToursProfile()
    {
        CreateMap<ShoppingCartDto, ShoppingCart>().IncludeAllDerived()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(item => new OrderItem(item.IdTour, item.Name, item.Price))));
        CreateMap<ShoppingCart, ShoppingCartDto>().IncludeAllDerived()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(h => h.Name)));

        CreateMap<EquipmentDto, Equipment>().ReverseMap();
        CreateMap<ProblemDto, Problem>().ReverseMap();
        CreateMap<PointsDto, Points>().ReverseMap();
        CreateMap<TouristEquipmentDto, TouristEquipment>().ReverseMap();
        CreateMap<PreferenceDto, Preference>().ReverseMap();
        CreateMap<TourIn, Tour>().ReverseMap();
        CreateMap<TourReviewDto, TourReview>().ReverseMap();
        CreateMap<EquipmentManagmentDto, EquipmentManagment>().ReverseMap();
        CreateMap<ObjectDto, Object>().ReverseMap();
    }
}