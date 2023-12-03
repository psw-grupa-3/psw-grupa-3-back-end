using Explorer.API.Controllers.Encounter;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.Encounters.Tests.Integration.Encounter
{
    [Collection("Sequential")]
    public class EncounterCommandTests: BaseEncounterIntegrationTest
    {
        public EncounterCommandTests(EncounterTestFactory factory) : base(factory){}
        
           [Fact]
           public void Activates()
            {
                // Arrange
                using var scope = Factory.Services.CreateScope();
                var controller = CreateController(scope);
                var enocunterId = -1;
                var personLocation = new PersonLocationDto
                {
                    PersonId = -1,
                    Latitude = 0.0,
                    Longitude = 0.0,
                };

                // Act
                var result = ((ObjectResult)controller.Activate(enocunterId, personLocation).Result)?.Value as EncounterDto;

                // Assert - Response
                result.ShouldNotBeNull();

                // Assert - Database
            }
        

        private static EncounterController CreateController(IServiceScope scope)
        {
            return new EncounterController(scope.ServiceProvider.GetRequiredService<IEncounterService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
