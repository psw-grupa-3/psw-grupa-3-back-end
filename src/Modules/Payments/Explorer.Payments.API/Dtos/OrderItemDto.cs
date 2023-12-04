namespace Explorer.Payments.API.Dtos
{
    public class OrderItemDto
    {
        public int IdTour { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
        public string Image { get; init; }
    }
}
