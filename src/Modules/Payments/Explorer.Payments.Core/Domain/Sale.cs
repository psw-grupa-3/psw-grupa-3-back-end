using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Newtonsoft.Json;
using JsonConstructorAttribute = Newtonsoft.Json.JsonConstructorAttribute;

namespace Explorer.Payments.Core.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Sale : JsonEntity
    {
        [NotMapped]
        [JsonProperty]
        public List<Tour>? ToursOnSale { get; set; } = new List<Tour>();

        [NotMapped]
        [JsonProperty]
        public DateTime SaleStart { get; set; }

        [NotMapped]
        [JsonProperty]
        public DateTime SaleEnd { get; set; }

        [NotMapped]
        [JsonProperty]
        public int DiscountPercentage { get; set; }

        [NotMapped]
        [JsonProperty]
        public bool IsActive { get; set; }

        public Sale() { }

        [JsonConstructor]
        public Sale(List<Tour> tours, DateTime start, DateTime end, int discount, bool isActive) 
        {
            ToursOnSale = tours;
            SaleStart = start;
            SaleEnd = end;
            DiscountPercentage = discount;
            IsActive = isActive;
        }

        public override void ToJson()
        {
            JsonObject = JsonConvert.SerializeObject(this, Formatting.Indented) ??
                         throw new JsonSerializationException("Exception! Could not serialize object!");
        }
        public override void FromJson()
        {
            var sale = JsonConvert.DeserializeObject<Sale>(JsonObject ??
                                                           throw new NullReferenceException(
                                                               "Exception! No object to deserialize!")) ??
                       throw new NullReferenceException("Exception! Tour is null!");
            ToursOnSale = sale.ToursOnSale;
            SaleStart = sale.SaleStart;
            SaleEnd = sale.SaleEnd;
            DiscountPercentage = sale.DiscountPercentage;
            IsActive = sale.IsActive;
        }
    }
}
