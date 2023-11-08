namespace Explorer.Tours.API.Dtos
{
    public class ShoppingCartDto
    {
         public int Id { get; set; }
         public int IdUser { get; init; }
         public List<OrderItemDto> Items { get; init; }
    }
}
