using static Explorer.Payments.API.Enums.OrderItemEnums;

namespace Explorer.Payments.API.Dtos
{
    public class OrderItemDto
    {
        public OrderItemType Type { get; set; }
        public int IdType { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public string Image { get; init; }
    }
}
