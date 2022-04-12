using AutoMapper;
using CleanArch.Api.ViewModels.Products;
using CleanArch.Application.Products.Create;
using CleanArch.Application.Products.Edit;
using CleanArch.Query.Models.Products;
using CleanArch.Query.Products.GetById;
using CleanArch.Query.Products.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CleanArch.Api.Controllers.V1
{
    [ApiVersion("1.0", Deprecated = true)]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public virtual async Task<List<ProductReadModel>> GetProducts()
        {
            var Products = await _mediator.Send(new GetProductListQuery());
            var ViewModels = _mapper.Map<List<ProductReadModel>>(Products);
            return ViewModels;
        }
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<ProductViewModel>> GetProductById(long id)
        {
            var FindedProduct = await _mediator.Send(new GetProductByIdQuery(id));
            if (FindedProduct == null)
                return NotFound("Product Not Found");
            return _mapper.Map<ProductViewModel>(FindedProduct).AddLinks();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            var url = Url.Action(nameof(GetProductById), "Product", new { id = result }, Request.Scheme);
            return Created(url, result);
        }
        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
