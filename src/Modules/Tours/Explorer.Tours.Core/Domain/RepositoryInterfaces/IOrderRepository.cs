using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain.Order;
using FluentResults;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IOrderRepository : ICrudRepository<ShoppingCart>
    {
        public Result<ShoppingCartDto> GetByUserId(int id);
    }
}
