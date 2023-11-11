using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;

namespace Explorer.Tours.Core.Domain.Order
{
    public class OrderItem : ValueObject
    {
        public int IdTour { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }

        [JsonConstructor]
        public OrderItem(int idTour, string name, double price)
        {
            IdTour = idTour;
            Name = name;
            Price = price;
            Validate();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IdTour;
            yield return Name;
            yield return Price;
        }
        private void Validate()
        {
            if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Invalid name");
            if (Price < 0) throw new ArgumentException("Invalid price");
            if (IdTour == 0) throw new ArgumentException("Invalid TourId");
        }

    }
}
