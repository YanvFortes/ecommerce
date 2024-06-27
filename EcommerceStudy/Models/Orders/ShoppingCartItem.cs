using EcommerceStudy.Models.Products;

namespace EcommerceStudy.Models.Orders
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
