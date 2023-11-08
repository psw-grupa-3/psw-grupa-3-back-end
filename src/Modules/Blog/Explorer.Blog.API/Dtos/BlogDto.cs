namespace Explorer.Blog.API.Dtos
{
    public enum BlogStatus { DRAFT = 1, PUBLISHED, CLOSED };
    public class BlogDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public BlogStatus Status { get; set; } = BlogStatus.DRAFT;
        public string[] Images { get; set; }
        public List<BlogRatingDto>? Ratings { get; set; }
    }
}
