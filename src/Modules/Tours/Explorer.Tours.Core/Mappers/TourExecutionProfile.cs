using AutoMapper;
using Explorer.Tours.API.Dtos.TourExecutions;
using Explorer.Tours.Core.Domain.TourExecutions;

namespace Explorer.Tours.Core.Mappers
{
    public class TourExecutionProfile: Profile
    {

        public TourExecutionProfile()
        {
            CreateMap<TourExecutionDto, TourExecution>()
                .ForMember(dest => dest.Position, opt =>
                    opt.MapFrom(src =>
                        new Position(
                            src.Position.Latitude,
                            src.Position.Longitude,
                            src.Position.LastActivity)));

            CreateMap<TourExecution, TourExecutionDto>()
                .ForMember(dest => dest.Position, opt =>
                    opt.MapFrom(src =>
                        new PositionDto
                        {
                            Latitude = src.Position.Latitude,
                            Longitude = src.Position.Longitude,
                            LastActivity = src.Position.LastActivity

                        }));
        }
    }
}
