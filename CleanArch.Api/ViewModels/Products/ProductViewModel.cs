using CleanArch.Domain.ProductsAgg;
using CleanArch.Domain.Shared;

namespace CleanArch.Api.ViewModels.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Money Money { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public List<LinkDTO> Links { get; set; } = new List<LinkDTO>();
    }
}
