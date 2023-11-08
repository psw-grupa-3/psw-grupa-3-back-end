using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.API.Public.Shopping;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Order;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;

namespace Explorer.Tours.Core.UseCases.Shopping
{
    public class OrderService : CrudService<ShoppingCartDto, ShoppingCart>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(ICrudRepository<ShoppingCart> crudRepository, IMapper mapper, IOrderRepository orderRepository) : base(crudRepository, mapper)
        {
            _orderRepository = orderRepository;
        }

        public Result<ShoppingCartDto> GetByIdUser(int id)
        {
            return _orderRepository.GetByUserId(id);
        }
    }
}
