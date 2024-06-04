using AutoMapper;
using Ecommers.Core.Models.Categories;
using Ecommers.Core.Models.Products;
using Ecommers.DTO.Models.Category;
using Ecommers.DTO.Models.Product;
namespace Ecommers.Business.Mapper;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category,CategoryDTO>().ReverseMap();
        CreateMap<Product,ProductDTO>().ReverseMap();
    }
}
