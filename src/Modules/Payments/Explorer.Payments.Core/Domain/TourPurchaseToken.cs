using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;
using static Explorer.Payments.API.Enums.TourPurchaseTokenEnums;

namespace Explorer.Payments.Core.Domain
{
    public class TourPurchaseToken : Entity
    {
        [JsonPropertyName("Id")]
        public long TokenId => base.Id;
        public int UserId { get; init; }
        public TourPurchaseTokenType Type { get; init; }
        public int TypeId { get; init; }
        public DateTime PurchaseTime { get; init; }
        public string TourName { get; init; }
        public string TourImage { get; init; }

        public TourPurchaseToken(long id, int userId, int typeId, DateTime purchaseTime, string tourName, string tourImage, TourPurchaseTokenType type)
        {
            Id = id;
            UserId = userId;
            TypeId = typeId;
            PurchaseTime = purchaseTime;
            TourName = tourName;
            TourImage = tourImage;
            Type = type;
            Validate();
        }

        private void Validate()
        {
            if (UserId <= 0) throw new ArgumentOutOfRangeException();
            if (TypeId <= 0) throw new ArgumentOutOfRangeException();
            if (TourName == string.Empty || TourName == null) throw new ArgumentNullException();
            if (TourImage == string.Empty || TourImage == null) throw new ArgumentNullException();
        }
    }
}
