using System.Text.Json;
using Explorer.BuildingBlocks.Core.Domain;
using Newtonsoft.Json;

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
            return JsonConvert.SerializeObject(entity);
        }
        public TEntity FromJson()
        {
            return JsonConvert.DeserializeObject<TEntity>(JsonObject) ?? throw new Newtonsoft.Json.JsonException("Exception! Cannot deserialize object!");
        }
    }
}
