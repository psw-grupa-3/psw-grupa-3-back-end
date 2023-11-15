using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Shopping;
using Explorer.Tours.Core.Domain.Order;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Shopping
{
    public class OrderService : CrudService<ShoppingCartDto, ShoppingCart>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(ICrudRepository<ShoppingCart> crudRepository, IMapper mapper, IOrderRepository orderRepository) : base(crudRepository, mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Result<ShoppingCartDto> AddToCart(OrderItemDto orderItem, int userId)
        {
            var cart = _orderRepository.AddToCart(_mapper.Map<OrderItem>(orderItem), userId);
            return MapToDto(cart.Value);
        }

        public Result<ShoppingCartDto>? GetByIdUser(int id)
        {
            return _orderRepository.GetByUserId(id);
        }
    }
}
