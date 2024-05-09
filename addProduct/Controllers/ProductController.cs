using addProduct.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace addProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<ProductDetail> products = new List<ProductDetail>();

        [HttpGet]
        public IActionResult getAllProduct()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult getProductByID(string id)
        {
            try {
                //LinQ [Object] Query
                var product = products.FirstOrDefault(p => p.productID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult createProduct(Product product)
        {
            var productDetail = new ProductDetail
            {
                productID = Guid.NewGuid(),
                productName = product.productName,
                productPrice = product.productPrice,
            };
            products.Add(productDetail);
            return Ok(new
            {
                Success = true,
                Data = products
            });
        }

        [HttpPut("{id}")]
        public IActionResult editProduct(string id, ProductDetail productEdit)
        {
            try
            {
                //LinQ [Object] Query
                var product = products.FirstOrDefault(p => p.productID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }

                if (id != product.productID.ToString())
                {
                    return BadRequest();
                }
                product.productName = productEdit.productName;
                product.productPrice = productEdit.productPrice;
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult deleteProduct(string id)
        {
            try
            {
                //LinQ [Object] Query
                var product = products.FirstOrDefault(p => p.productID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                products.Remove(product);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
