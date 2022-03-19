using CleanArch.Infrastructure.Persistent.EF;
using CleanArch.Query.DTOs;
using CleanArch.Query.Models.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductReadModel>
    {
        private readonly IProductReadRepository _repository; 

        public GetProductByIdQueryHandler(IProductReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductReadModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.ProductId);
        }
    }
}
