namespace AssementCoreApplication.Models
{
    public class OrderModel
    {
        public decimal OrderAmount { get; set; }
        public required string Customertype { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
