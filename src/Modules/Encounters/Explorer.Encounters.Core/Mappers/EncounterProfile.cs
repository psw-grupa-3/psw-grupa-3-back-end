using AutoMapper;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.Participants;
using Explorer.Encounters.Core.Domain.SolvingStrategies;

namespace Explorer.Encounters.Core.Mappers
{
    public class EncounterProfile: Profile
    {
        public EncounterProfile()
        {
            CreateMap<LocationDto, Location>().ReverseMap();
            CreateMap<ParticipantDto, Participant>().ReverseMap();
            CreateMap<CompleterDto, Completer>().ReverseMap();
            CreateMap<EncounterDto, Encounter>().ReverseMap();
            CreateMap<SocialEncounterDto, SocialEncounter>().ReverseMap();
            CreateMap<HiddenEncounterDto, HiddenEncounter>().ReverseMap();
        }
    }
}
