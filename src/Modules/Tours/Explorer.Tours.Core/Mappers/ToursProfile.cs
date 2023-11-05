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
        CreateMap<OrderItemDto, OrderItem>();
        CreateMap<ShoppingCartDto, ShoppingCart>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(itemDto => new OrderItem(itemDto.IdTour, itemDto.Name, itemDto.Price))));
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(orderItem => new OrderItemDto { IdTour = orderItem.IdTour, Name = orderItem.Name, Price = orderItem.Price })));

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