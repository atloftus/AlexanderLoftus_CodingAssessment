using CsvHelper.Configuration;


namespace AlexanderLoftus_CodingAssessment.Models
{
    public class OrderProductMap : ClassMap<OrderProduct>
    {
        public OrderProductMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.OrderId).Name("OrderId");
            Map(m => m.ProductId).Name("ProductId");
            Map(m => m.CouponId).Name("CouponId").Optional();
            Map(m => m.Quantity).Name("Quantity").Optional();
        }
    }



    public class OrderProduct : TableBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? CouponId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Coupon? Coupon { get; set; }
    }
}