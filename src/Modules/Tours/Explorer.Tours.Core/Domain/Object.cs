using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public enum ObjectType { WC, RESTAURANT, PARKING, OTHER };
    public class Object:Entity
    {
        public string ObjectName {  get; init; }
        public string ObjectDescription {  get; init; }
        public string[] ObjectImages { get; init; }
        public ObjectType Type { get; init; }

        public Object(string objectName, string objectDescription, string[] objectImages, ObjectType type)
        {
            if (string.IsNullOrEmpty(objectName)) throw new ArgumentNullException("Invalid or empty name.");
            if (string.IsNullOrEmpty(objectDescription)) throw new ArgumentNullException("Invalid or empty description.");
            ObjectName = objectName;
            ObjectDescription = objectDescription;
            ObjectImages = objectImages;
            Type = type;
        }
    }
}
