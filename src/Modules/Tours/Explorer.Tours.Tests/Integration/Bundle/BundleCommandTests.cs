using Explorer.API.Controllers.Author;
using Explorer.API.Controllers.Encounter;
using Explorer.Encounters.API.Public;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Tests.Integration.Bundle
{
    public class BundleCommandTests : BaseToursIntegrationTest
    {
        public BundleCommandTests(ToursTestFactory factory) : base(factory)
        {

        }

        [Fact]
        public void Create_bundle()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var bundle = new BundleDto() { };


            var result = ((ObjectResult)controller.Create(bundle).Result)?.Value as BundleDto;

            result.ShouldNotBeNull();
        }

        private static BundleController CreateController(IServiceScope scope)
        {
            return new BundleController(scope.ServiceProvider.GetRequiredService<IBundleService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
