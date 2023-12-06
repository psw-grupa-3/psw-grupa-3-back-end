using Explorer.API.Controllers.Encounter;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Tests.Integration.Encounter
{
    [Collection("Sequential")]
    public class HiddenEncounterCommandTest : BaseEncounterIntegrationTest
    {
        public HiddenEncounterCommandTest(EncounterTestFactory factory) : base(factory) { }

        [Fact]
        public void Solves_hidden()
        {
            // Arange
            using var scope = Factory.Services.CreateScope();
            var controller = CreateController(scope);
            var encounterId = -5;
            var personLocation = new ParticipantLocationDto
            {
                Username = "participant11",
                Latitude = 45.244442,
                Longitude = 19.841521
            };

            // Act
            var result = ((ObjectResult)controller.SolveHidden(encounterId, personLocation).Result)?.Value as HiddenEncounterDto;

            // Assert - Response
            result.ShouldNotBeNull();
            result.Participants.Count.ShouldBe(0);

            // Assert - Database
        }

        private static HiddenEncounterController CreateController(IServiceScope scope)
        {
            return new HiddenEncounterController(scope.ServiceProvider.GetRequiredService<IHiddenEncounterService>())
            {
                ControllerContext = BuildContext("-1")
            };
        }
    }
}
