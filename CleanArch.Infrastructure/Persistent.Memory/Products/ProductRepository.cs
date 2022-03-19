using CleanArch.Domain.Products;
using CleanArch.Domain.Products.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.Memory.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public async Task<Product> GetById(long id)
        {
            var result = _context.Products.FirstOrDefault(a => a.Id == id);
            return await Task.FromResult(result);
        }

        public List<Product> GetProducts()
        {
            return _context.Products;
        }

        public bool IsProductExist(long id)
        {
            return _context.Products.Any(p => p.Id == id);
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
        }

        public async Task Save()
        {
            throw new NotImplementedException();
        }

        public async void Update(Product product)
        {
            var Oproducts = GetById(product.Id);
            _context.Products.Remove(await Oproducts);
            Add(product);
        }
    }
}
