using CleanArch.Query.Models.Products;
using CleanArch.Query.Shared.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Query.Repositories
{
    public class ProductReadRepository : BaseReadRepository<ProductReadModel>  , IProductReadRepository
    {
        public ProductReadRepository(IMongoClient client) : base(client)
        {

        }
    }
}
