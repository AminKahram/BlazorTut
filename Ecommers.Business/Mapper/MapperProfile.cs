using AutoMapper;
using Ecommers.Core.Models.Categories;
using Ecommers.DTO.Models.Category;
namespace Ecommers.Business.Mapper;

internal class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Category,CategoryDTO>().ReverseMap();
    }
}
