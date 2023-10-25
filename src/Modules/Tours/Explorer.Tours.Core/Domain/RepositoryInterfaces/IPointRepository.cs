using Explorer.Tours.API.Dtos;

namespace Explorer.Tours.Core.Domain.RepositoryInterfaces
{
    public interface IPointRepository
    {
        List<PointsDto> GetByTourId(int id);
    }
}
