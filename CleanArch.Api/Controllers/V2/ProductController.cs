using AutoMapper;
using CleanArch.Api.ViewModels.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class ProductController : Api.Controllers.V1.ProductController
    {
        public ProductController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
        public override async Task<ActionResult<ProductViewModel>> GetProductById(long id)
        {
            return new ProductViewModel();
        }
    }
}
