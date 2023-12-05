namespace Explorer.Payments.API.Dtos
{
    public class CouponDto
    {
        public string Code { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? TourId { get; set; }
        public int AuthorId { get; set; }
    }
}