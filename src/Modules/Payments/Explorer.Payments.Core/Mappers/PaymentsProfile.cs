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
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(itemDto => new OrderItem(itemDto.IdTour, itemDto.Name, itemDto.Price, itemDto.Image,itemDto.CouponCode))));


        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(orderItem => new OrderItemDto { IdType = orderItem.IdType, Name = orderItem.Name, Price = orderItem.Price, Image = orderItem.Image, Type = orderItem.Type.ToString() })));
        CreateMap<TourPurchaseToken, TourPurchaseTokenDto>().ForMember(dest => dest.PurchaseTime, opt => opt.MapFrom(src => src.PurchaseTime.ToShortDateString()))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
        CreateMap<TourPurchaseTokenDto, TourPurchaseToken>();
        CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        CreateMap<CouponDto, Coupon>().ReverseMap();
        CreateMap<WalletDto, Wallet>().ReverseMap();
        CreateMap<SaleDto, Sale>().ReverseMap();

    }
}
