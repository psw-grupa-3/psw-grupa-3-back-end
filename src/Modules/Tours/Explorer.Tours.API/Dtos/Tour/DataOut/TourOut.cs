using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Tour.DataOut
{
    public class TourOut
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficult { get; set; }
        public string? Tags { get; set; }
        public TourStatus Status { get; set; }
        public double Price { get; set; }
        public int AuthorId { get; set; }
    }

    public enum TourStatus
    {
        Draft
    }
}
