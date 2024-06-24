using EcommerceStudy.Data.Enums;
namespace EcommerceStudy.Models.Products;

public class IPhone : Product
{
    public int StorageGB { get; set; }
    public int RamGB { get; set; }
    public string Color { get; set; }
    public IPhoneModel Model { get; set; }
}
