using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class TourPurchaseToken : Entity
    {
        [JsonPropertyName("Id")]
        public long TokenId => base.Id;
        public int UserId { get; init; }
        public int TourId { get; init; }
        public DateTime PurchaseTime { get; init; }

        public TourPurchaseToken(long id, int userId, int tourId, DateTime purchaseTime)
        {
            Id = id;
            UserId = userId;
            TourId = tourId;
            PurchaseTime = purchaseTime;
            Validate();
        }

        private void Validate()
        {
            if (UserId <= 0) throw new ArgumentOutOfRangeException();
            if (TourId <= 0) throw new ArgumentOutOfRangeException();
        }
    }
}
