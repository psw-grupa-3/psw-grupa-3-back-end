using Explorer.Stakeholders;

namespace Explorer.Stakeholders.API.Dtos
{
    public class UserAdminDto
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }

    }

    public enum UserRole
    {
        Administrator,
        Author,
        Tourist
    }
}

