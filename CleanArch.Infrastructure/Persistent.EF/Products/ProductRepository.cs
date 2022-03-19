using CleanArch.Domain.Products;
using CleanArch.Domain.Products.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Persistent.EF.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly AddDbContext _context;

        public ProductRepository(AddDbContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Add(product);
        }

        public async Task<Product> GetById(long id)
        {
            return await _context.Products.FirstOrDefaultAsync(f => f.Id == id);
        }

        public bool IsProductExist(long id)
        {
            return _context.Products.Any(f => f.Id == id);
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}
