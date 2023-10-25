namespace Explorer.Stakeholders.API.Dtos;

public class UserProfileDto
{
    public int Id { get; set; }
    public long UserId { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Email { get; init; }
    public string Picture { get; init; }
    public string Bio { get; init; }
    public string Quote { get; init; }

}