using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.GetById;
using CleanArch.Query.Products.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return await _mediator.Send(new GetProductListQuery());
        }
        [HttpGet("{id}")]
        public async Task<ProductReadModel> GetProductById(long id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }
    }
}
