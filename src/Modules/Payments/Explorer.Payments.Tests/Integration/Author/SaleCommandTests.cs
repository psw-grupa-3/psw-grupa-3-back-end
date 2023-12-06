using Explorer.API.Controllers.Administrator.Administration;
using Explorer.API.Controllers.Shopping;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using Explorer.Payments.Tests;

namespace Explorer.Tours.Tests.Integration.Administration
{
    [Collection("Sequential")]
    public class SaleCommandTests : BasePaymentsIntegrationTest
    {
        public SaleCommandTests(PaymentsTestFactory factory) : base(factory) { }

        [Fact]
        public void Creates()
        {
            // Arrange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var dbContext = scope.ServiceProvider.GetRequiredService<PaymentsContext>();
            var newEntity = new SaleDto
            {
                /*ToursOnSale = new List<Tour>
                {
                    new Tour { /* Tour details here  },
                },*/
                SaleStart = DateTime.Now,
                SaleEnd = DateTime.Now.AddDays(7),
                DiscountPercentage = 15,
                IsActive = true
            };

            // Act
            var result = ((ObjectResult)controller.Create(newEntity).Result)?.Value as SaleDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Id.ShouldNotBe(0);
            result.SaleStart.ShouldBe(newEntity.SaleStart);
            result.SaleEnd.ShouldBe(newEntity.SaleEnd);
            result.ToursOnSale.ShouldNotBeNull();
            result.ToursOnSale.Count.ShouldBe(2); // Assuming two tours were added

            // Assert - Database
            var storedEntity = dbContext.Sales.FirstOrDefault(i => i.Id == result.Id);
            storedEntity.ShouldNotBeNull();
            storedEntity.SaleStart.ShouldBe(result.SaleStart);
            //storedEntity.SaleTours.Count.ShouldBe(2); // Assuming two tours were added to SaleTours
        }

        // ... (Similar modifications for other test methods)

        private static SaleController CreateController(IServiceScope scope)
        {
            return new SaleController(scope.ServiceProvider.GetRequiredService<ISaleService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
