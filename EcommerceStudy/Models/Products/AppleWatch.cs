using EcommerceStudy.Data.Enums;
namespace EcommerceStudy.Models.Products;

public class AppleWatch : Product
{
    public int StorageGB { get; set; }
    public string Color { get; set; }
    public AppleWatchModel Model { get; set; }
}
