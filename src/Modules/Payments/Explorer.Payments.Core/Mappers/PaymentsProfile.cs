using AutoMapper;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain.Order;
using Explorer.Payments.Core.Domain;

namespace Explorer.Payments.Core.Mappers;

public class PaymentsProfile : Profile
{
    public PaymentsProfile()
    {
        CreateMap<ShoppingCartDto, ShoppingCart>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(itemDto => new OrderItem(itemDto.IdTour, itemDto.Name, itemDto.Price, itemDto.Image))));
        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(orderItem => new OrderItemDto { IdTour = orderItem.IdTour, Name = orderItem.Name, Price = orderItem.Price, Image = orderItem.Image })));
        CreateMap<TourPurchaseToken, TourPurchaseTokenDto>().ForMember(dest => dest.PurchaseTime, opt => opt.MapFrom(src => src.PurchaseTime.ToShortDateString()));
        CreateMap<TourPurchaseTokenDto, TourPurchaseToken>().ReverseMap();
        CreateMap<OrderItemDto, OrderItem>().ReverseMap();
    }
}
