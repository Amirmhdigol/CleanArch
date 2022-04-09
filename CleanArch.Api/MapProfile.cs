using AutoMapper;
using CleanArch.Api.ViewModels.Products;
using CleanArch.Query.Models.Products;

namespace CleanArch.Api
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductReadModel,ProductViewModel>().ReverseMap();
        }
    }
}
