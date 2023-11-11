using Explorer.BuildingBlocks.Core.Domain;
using System.Text.Json.Serialization;

namespace Explorer.Tours.Core.Domain.Tours
{
    public class Guide : Entity
    {
        [JsonPropertyName("Name")]
        public string Name { get; init; }
        [JsonPropertyName("Surname")]
        public string Surname { get; init; }
        [JsonPropertyName("Email")]
        public string Email { get; init; }

        [JsonConstructor]
        public Guide(long id, string name, string surname, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentNullException("Invalid name");
            if (string.IsNullOrEmpty(Surname))
                throw new ArgumentNullException("Invalid surname");
            if (string.IsNullOrEmpty(Email))
                throw new ArgumentNullException("Invalid email");
        }
    }
}
