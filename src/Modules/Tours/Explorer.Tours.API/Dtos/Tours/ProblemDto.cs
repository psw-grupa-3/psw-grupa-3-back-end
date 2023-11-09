using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Tours
{
    public class ProblemDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public bool Priority { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public int TourId { get; set; }
        public int TouristId { get; set; }
        public bool IsSolved { get; set; }
        public string UnsolvedProblemComment { get; set; }
        public DateTime Deadline { get; set; }
    }
}
