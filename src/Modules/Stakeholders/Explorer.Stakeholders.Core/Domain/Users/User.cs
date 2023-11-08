using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;
using static Explorer.Stakeholders.API.Enums.UserEnums;

namespace Explorer.Stakeholders.Core.Domain.Users;

public class User : Entity
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public UserRole Role { get; private set; }
    public bool IsActive { get; set; }
    public List<Follower> Followers { get; private set; }

    public User(string username, string password, UserRole role, bool isActive, List<Follower> followers)
    {
        Username = username;
        Password = password;
        Role = role;
        IsActive = isActive;
        Followers = followers;
        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Username)) throw new ArgumentException("Invalid Name");
        if (string.IsNullOrWhiteSpace(Password)) throw new ArgumentException("Invalid Password");
    }

    public string GetPrimaryRoleName()
    {
        return Role.ToString().ToLower();
    }

    public void AddFollower(User follower)
    {
        if (follower is null) throw new ArgumentNullException(nameof(follower));
        if (!Followers.Any(f => f.Id == follower.Id))
        {
            Followers.Add(new(follower.Id, follower.Username, DateTime.Now));
        }
    }

    public void RemoveFollower(User follower)
    {
        if (follower is null) throw new ArgumentNullException(nameof(follower));
        if (Followers.Any(f => f.Id == follower.Id))
        {
            Followers.Remove(new(follower.Id, follower.Username, DateTime.Now));
        }
    }
}
