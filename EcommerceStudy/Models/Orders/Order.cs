﻿namespace EcommerceStudy.Models.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
