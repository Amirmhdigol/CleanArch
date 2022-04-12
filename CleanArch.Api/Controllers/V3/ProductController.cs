using CleanArch.Api.ViewModels.Products;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.GetList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers.V3
{
    [ApiVersion("3.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public List<ProductViewModel> GetProducts()
        {
            var Products = new List<ProductViewModel>();
            return Products;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct()
        {
            return Created("123", 1);
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct()
        {
            return Ok();
        }
    }
}
