using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class OrderItemDto
    {
        public int IdTour { get; init; }
        public string Name { get; init; }
        public double Price { get; init; }
    }
}
