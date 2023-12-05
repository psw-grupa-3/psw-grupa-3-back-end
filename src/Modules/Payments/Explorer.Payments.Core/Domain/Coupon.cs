using System;

namespace Explorer.Payments.Core.Domain
{
    internal class Coupon
    {
        
        public string Code { get; init; }
        public decimal Discount { get; init; }
        public DateTime? ExpiryDate { get; init; }
        public int TourId { get; init; }
        public int AuthorId { get; init; }

       
        public Coupon(string code, decimal discount, DateTime? expiryDate, int tourId, int authorId)
        {
            Code = code;
            Discount = discount;
            ExpiryDate = expiryDate;
            TourId = tourId;
            AuthorId = authorId;
            Validate();
        }

        
        private void Validate()
        {
            if (string.IsNullOrEmpty(Code))
                throw new ArgumentException("Invalid coupon code");

            if (Discount < 0)
                throw new ArgumentException("Invalid discount value");

            if (TourId <= 0)
                throw new ArgumentException("Invalid TourId");

            if (AuthorId <= 0)
                throw new ArgumentException("Invalid AuthorId");

            if (ExpiryDate.HasValue && ExpiryDate.Value < DateTime.Now)
                throw new ArgumentException("Coupon has expired");
        }
    }
}
