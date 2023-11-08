using System.Text.Json;
using System.Text.RegularExpressions;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.BuildingBlocks.Infrastructure.Database
{
    public class DbEntity<TEntity> : Entity
        where TEntity : Entity
    {
        public string JsonObject { get; protected set; }

        public DbEntity() {}

        public DbEntity(TEntity entity)
        {
            Id = entity.Id;
            JsonObject = ToJson(entity);
        }
        private string ToJson(TEntity entity)
        {
            return JsonSerializer.Serialize(entity, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
        public TEntity FromJson()
        {
            var objectToDeserialize = Regex.Replace(JsonObject, "\"Id\":\\s*0", "\"Id\":" + Id.ToString());
            return JsonSerializer.Deserialize<TEntity>(objectToDeserialize) ?? throw new JsonException("Exception! Cannot deserialize object!");
        }
    }
}
