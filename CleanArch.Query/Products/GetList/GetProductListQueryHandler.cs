using CleanArch.Infrastructure.Persistent.EF;
using CleanArch.Query.DTOs;
using CleanArch.Query.Models.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Products.GetList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductReadModel>>
    {
        private readonly IProductReadRepository _repository;

        public GetProductListQueryHandler(IProductReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductReadModel>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
