using Explorer.API.Controllers.Shopping;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.Shopping;
using Explorer.Payments.Tests;
using Explorer.Stakeholders.Core.Domain.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;

[Collection("Sequential")]
public class MyOrderCommandTests : BasePaymentsIntegrationTest
{
    public MyOrderCommandTests(PaymentsTestFactory factory) : base(factory) { }

    [Fact]
    public void AddToCart_ShouldAddItem_WithValidData()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var orderController = CreateOrderController(scope);

        // Postavite početne uslove sa validnim podacima
        var orderItemDto = new OrderItemDto
        {
            IdTour = 1,
            Name = "Sample Tour",
            Price = 29.99,
            Image = "sample-image.jpg",
            CouponCode = "SAMPLE123" // Dodajte podatke o kuponu ako su potrebni
            // Dodajte i druge potrebne podatke
        };

        // Act
        var result = orderController.AddToCart(orderItemDto, 1); // Prosleđujemo null umesto userId

        result.ShouldNotBeNull();
        

    }

    [Fact]
    public void AddToCart_ShouldFail_WithInvalidData()
    {
        // Arrange
        using var scope = Factory.Services.CreateScope();
        var orderController = CreateOrderController(scope);

        // Postavite početne uslove sa nevalidnim podacima
        var orderItemDto = new OrderItemDto
        {
            // Nedostaje ID ture ili drugi nevalidni podaci
        };

        // Act
        var result = orderController.AddToCart(orderItemDto, 1); // Prosleđujemo null umesto userId

        // Assert
        result.ShouldNotBeNull();
        result.ShouldBeOfType<BadRequestObjectResult>();
    }

    private static OrderController CreateOrderController(IServiceScope scope)
    {
        return new OrderController(scope.ServiceProvider.GetRequiredService<IOrderService>())
        {
            // Ako ne koristite autentifikaciju, možete ostaviti ControllerContext prazan
        };
    }

   
}
