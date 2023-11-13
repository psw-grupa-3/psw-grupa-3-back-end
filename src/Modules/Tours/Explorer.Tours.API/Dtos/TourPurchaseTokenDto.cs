using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class TourPurchaseTokenDto
    {
        public long TokenId { get; set; }
        public int UserId { get; set; }
        public int TourId { get; set; }
        public DateTime PurchaseTime { get; set; }
    }
}
