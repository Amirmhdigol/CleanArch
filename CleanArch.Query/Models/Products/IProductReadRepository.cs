using CleanArch.Query.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Models.Products
{
    public interface IProductReadRepository : IBaseReadRepository<ProductReadModel>
    {

    }
}
