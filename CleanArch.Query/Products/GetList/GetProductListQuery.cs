using CleanArch.Query.DTOs;
using CleanArch.Query.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Products.GetList
{
    public record GetProductListQuery : IRequest<List<ProductReadModel>>;
}
