using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcommerceStudy.Models;
using EcommerceStudy.Models.Products;
using System.IO;
using System.Threading.Tasks;

namespace EcommerceStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly Admin _admin;

        public ProductsController(Admin admin)
        {
            _admin = admin;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromForm] Product product, IFormFile photo)
        {
            if (photo != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await photo.CopyToAsync(memoryStream);
                    product.Photo = memoryStream.ToArray();
                }
            }

            await _admin.AddProduct(product);
            return Ok();
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] Product product)
        {
            _admin.AddProduct(product);
            return Ok("Product added successfully.");
        }

        [HttpPut("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            _admin.UpdateProduct(product);
            return Ok("Product updated successfully.");
        }

        [HttpDelete("RemoveProduct/{productId}")]
        public IActionResult RemoveProduct(int productId)
        {
            _admin.RemoveProduct(productId);
            return Ok("Product removed successfully.");
        }

        [HttpGet("GetProduct/{productId}")]
        public IActionResult GetProduct(int productId)
        {
            var product = _admin.GetProduct(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _admin.GetAllProducts();
            return Ok(products);
        }
    }
}
