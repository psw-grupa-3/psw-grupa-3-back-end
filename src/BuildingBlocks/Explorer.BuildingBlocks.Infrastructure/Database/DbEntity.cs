using System.Text.Json;
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
            return JsonSerializer.Deserialize<TEntity>(JsonObject) ?? throw new JsonException("Exception! Cannot deserialize object!");
        }
    }
}
