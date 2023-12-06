using Explorer.Tours.API.Dtos.Tours;

namespace Explorer.Tours.API.Dtos;
public class CampaignDto
{
    public int Id { get; set; }
    public List<TourDto> Tours { get; set; }
    public int TouristId { get; set; }
}