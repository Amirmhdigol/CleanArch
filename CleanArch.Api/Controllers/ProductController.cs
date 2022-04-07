using CleanArch.Application.Products.Create;
using CleanArch.Application.Products.Edit;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.GetById;
using CleanArch.Query.Products.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<List<ProductReadModel>> GetProducts() 
        {
            return await _mediator.Send(new GetProductListQuery ());
        }
        [HttpGet("{id}")]
        public async Task<ProductReadModel> GetProductById(long id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));   
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command,cancellationToken);
            var url = Url.Action(nameof(GetProductById), "Product", new { id = result },Request.Scheme);
            return Created(url,result);
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);  
            return Ok();
        }
    }
}
