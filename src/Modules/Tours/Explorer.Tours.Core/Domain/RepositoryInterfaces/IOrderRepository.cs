using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.Core.Domain.Order;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IOrderRepository : ICrudRepository<ShoppingCart>
    {

    }
}
