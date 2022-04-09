namespace CleanArch.Api.ViewModels.Products
{
    public static class ProductLinkGenerator
    {
        private static string ProductUrl = "https://localhost:7087/Product";
        public static ProductViewModel AddLinks(this ProductViewModel productViewModel)
        {
            var Links = new List<LinkDTO>()
            {
                new LinkDTO(ProductUrl,"update_product",HttpMethod.Put.Method),
                new LinkDTO($"{ProductUrl}/{productViewModel.Id}","delete_product",HttpMethod.Delete.Method)
            };
            productViewModel.Links.AddRange(Links);
            return productViewModel;
        }

        public static List<ProductViewModel> AddLinks(this List<ProductViewModel> productViewModel)
        {

            productViewModel.ForEach(item =>
            {
                var Links = new List<LinkDTO>()
            {
                new LinkDTO(ProductUrl,"update_product",HttpMethod.Put.Method),
                new LinkDTO($"{ProductUrl}/{item.Id}","delete_product",HttpMethod.Delete.Method)
            };
                item.Links.AddRange(Links);
            });
            return productViewModel;
        }
    }
}
