using Ecommers.DTO.Models.Category;

namespace Ecommers.Business.Repository.IRepository;

public interface ICategoryRepository
{
    CategoryDTO Create(CategoryDTO addModel);
    CategoryDTO Update(CategoryDTO editModel);
    int Delete(int CategoryId);
    IEnumerable<CategoryDTO> GetAll();
    CategoryDTO GetCategory(int CategoryId);
}
