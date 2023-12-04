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
                var encounterId = -1;
                var personLocation = new ParticipantLocationDto
                {
                    Username = "participant1",
                    Latitude = 45.243952,
                    Longitude = 19.841275
                };
            
                // Act
                var result = ((ObjectResult)controller.Activate(encounterId, personLocation).Result)?.Value as EncounterDto;

                // Assert - Response
                result.ShouldNotBeNull();

                // Assert - Database
           }

           [Fact]
           public void Activates_fails_out_of_range()
           {
               // Arrange
               using var scope = Factory.Services.CreateScope();
               var controller = CreateController(scope);
               var encounterId = -1;
               var personLocation = new ParticipantLocationDto
               {
                   Username = "participant1",
                   Latitude = 45.241695,
                   Longitude = 19.842555
               };

               // Act
               var result = ((ObjectResult)controller.Activate(encounterId, personLocation).Result)?.Value as EncounterDto;

               // Assert - Response
               result.ShouldNotBeNull();

               // Assert - Database
           }

           [Fact]
           public void Activates_fails_already_activated()
           {
               // Arrange
               using var scope = Factory.Services.CreateScope();
               var controller = CreateController(scope);
               var encounterId = -2;
               var personLocation = new ParticipantLocationDto
               {
                   Username = "participant1",
                   Latitude = 45.244230,
                   Longitude = 19.841414
               };

               // Act
               var result = ((ObjectResult)controller.Activate(encounterId, personLocation).Result)?.Value as EncounterDto;

               // Assert - Response
               result.ShouldNotBeNull();

               // Assert - Database
           }

           [Fact]
           public void Solves_social()
           {
               // Arrange
               using var scope = Factory.Services.CreateScope();
               var controller = CreateController(scope);
               var encounterId = -4;
               var personLocation = new ParticipantLocationDto
               {
                   Username = "participant8",
                   Latitude = 44.653797,
                   Longitude = 21.147734
               };

               // Act
               var result = ((ObjectResult)controller.SolveSocial(encounterId, personLocation).Result)?.Value as EncounterDto;

               // Assert - Response
               result.ShouldNotBeNull();

               // Assert - Database
           }
           [Fact]
           public void Solves_social_fails_out_of_range()
           {
               // Arrange
               using var scope = Factory.Services.CreateScope();
               var controller = CreateController(scope);
               var encounterId = -3;
               var personLocation = new ParticipantLocationDto
               {
                   Username = "participant3",
                   Latitude = 37.970612,
                   Longitude = 23.724505
               };

               // Act
               var result = ((ObjectResult)controller.SolveSocial(encounterId, personLocation).Result)?.Value as EncounterDto;

               // Assert - Response
               result.ShouldNotBeNull();

               // Assert - Database
           }

           [Fact]
           public void Solves_social_fails_in_range()
           {
               // Arrange
               using var scope = Factory.Services.CreateScope();
               var controller = CreateController(scope);
               var encounterId = -3;
               var personLocation = new ParticipantLocationDto
               {
                   Username = "participant4",
                   Latitude = 37.971375,
                   Longitude = 23.726168
               };

               // Act
               var result = ((ObjectResult)controller.SolveSocial(encounterId, personLocation).Result)?.Value as EncounterDto;

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
