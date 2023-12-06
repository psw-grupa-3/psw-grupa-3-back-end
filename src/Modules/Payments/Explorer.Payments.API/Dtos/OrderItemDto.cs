using static Explorer.Payments.API.Enums.OrderItemEnums;

namespace Explorer.Payments.API.Dtos
{
    public class OrderItemDto
    {
        public int IdTour { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string CouponCode { get; set; }  

    }
}
