namespace Explorer.Tours.API.Dtos.Tour.DataIn
{
    public class TourIn
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficult { get; set; }
        public string? Tags { get; set; }
        public string Status { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
    }

    public enum TourStatus
    {
        Draft
    }
}
