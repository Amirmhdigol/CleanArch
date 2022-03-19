using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Products.Repository
{
    public interface IProductRepository
    {

        Task<Product> GetById(long id);
        void Add(Product product);
        void Update(Product product);
        void Remove(Product product);
        Task Save();
        bool IsProductExist(long id);
    }
}