using Explorer.BuildingBlocks.Core.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.Bundles
{
    public class Bundle : JsonEntity
    {
        [JsonProperty]
        public double Price { get; private set; }

        public override void FromJson()
        {
            throw new NotImplementedException();
        }

        public override void ToJson()
        {
            throw new NotImplementedException();
        }
    }
}
