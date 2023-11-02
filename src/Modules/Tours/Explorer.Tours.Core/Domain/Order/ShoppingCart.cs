using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;

namespace Explorer.Tours.Core.Domain.Order
{
    public class ShoppingCart : Entity
    {
        public int IdUser { get; init; }
        public List<OrderItem> Items { get; init; }
        public ShoppingCart(int idUser, List<OrderItem> items)
        {
            IdUser = idUser;
            Items = items;
            Validate();
        }
        private void Validate()
        {
            if (IdUser == 0) throw new ArgumentException("Invalid UserId");
        }

    }
}
