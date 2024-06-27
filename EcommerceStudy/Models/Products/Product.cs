using System.ComponentModel.DataAnnotations;
namespace EcommerceStudy.Models.Products;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public byte[] Photo { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
}
