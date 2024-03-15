using DemoEcommerce.Api.Services;
using eCommerce.Api.Services;
using eCommerce.Library.Models;
using eCommerce.Library.Response;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
    
        
            private readonly IProductService productService;
            private readonly ICategoryService categoryService;

            public ProductsController(IProductService productService, ICategoryService categoryService)
            {
                this.productService = productService;
                this.categoryService = categoryService;
            }

            [HttpGet]
            public async Task<ActionResult<List<Product>>> GetProductsAsync() => Ok(await productService.GetProductsAsync());

            [HttpGet("{id:int}")]
            public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
            {
                var product = await productService.GetProductByIdAsync(id);
                if (product is null)
                    return NotFound("Product not found");
                else
                    return Ok(product);
            }

            [HttpDelete("{id:int}")]
            public async Task<ActionResult<ServiceResponse>> DeleteProductAsync(int id)
            {
                var product = await productService.GetProductByIdAsync(id);
                if (product == null)
                    return NotFound("Product not found");

                var response = await productService.DeleteProductAsync(product.Id);
                return Ok(response);
            }

            [HttpPut]
            public async Task<ActionResult<ServiceResponse>> UpdateProductAsync(Product product)
            {
                var result = await productService.GetProductByIdAsync(product.Id);
                if (result == null)
                    return NotFound("Product not found");

                var response = await productService.UpdateProductAsync(product);
                return Ok(response);
            }

            [HttpPost]
            public async Task<ActionResult<ServiceResponse>> AddProductAsync(Product product)
            {
                if (product is null)
                    return BadRequest("Bad request");

                var result = await productService.AddProductAsync(product);
                if (result.Success)
                    return Ok(result);
                else
                    return BadRequest(result);
            }

            [HttpGet("categories")]
            public async Task<ActionResult<List<Category>>> GetCategoriesAsync() => Ok(await categoryService.GetCategoriesAsync());

        }
    }


