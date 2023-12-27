using AutoMapper;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain.Order;
using Explorer.Payments.Core.Domain;

namespace Explorer.Payments.Core.Mappers;

public class PaymentsProfile : Profile
{
    public PaymentsProfile()
    {
        CreateMap<ShoppingCartDto, ShoppingCart>().ReverseMap();
        CreateMap<TourPurchaseTokenDto, TourPurchaseToken>().ReverseMap();
        CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        CreateMap<CouponDto, Coupon>().ReverseMap();
        CreateMap<WalletDto, Wallet>().ReverseMap();
        CreateMap<SaleDto, Sale>().ReverseMap();
        CreateMap<TourInfoDto, TourInfo>().ReverseMap();

    }
}
