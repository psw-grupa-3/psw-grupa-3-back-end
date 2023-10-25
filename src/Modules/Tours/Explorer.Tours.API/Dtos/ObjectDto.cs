using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public enum ObjectType { WC, RESTAURANT, PARKING, OTHER };
    public class ObjectDto
    {
        public int Id { get; set; }
        public string ObjectName { get; set; }
        public string ObjectDescription { get; set; }
        public string[] ObjectImages { get; set; }
        public ObjectType Type { get; set; }

    }
}
