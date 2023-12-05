﻿using System.Text.Json.Serialization;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain.Order
{
    public class OrderItem : ValueObject
    {
        public int IdTour { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public string Image { get; init; }

        [JsonConstructor]
        public OrderItem(int idTour, string name, double price, string image)
        {
            IdTour = idTour;
            Name = name;
            Price = price;
            Image = image;
            Validate();
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return IdTour;
            yield return Name;
            yield return Price;
            yield return Image;
        }
        private void Validate()
        {
            if (string.IsNullOrEmpty(Name)) throw new ArgumentException("Invalid name");
            if (Price < 0) throw new ArgumentException("Invalid price");
            if (IdTour == 0) throw new ArgumentException("Invalid TourId");
            if (Image == string.Empty || Image == null) throw new ArgumentException("Invalid image");
        }

    }
}