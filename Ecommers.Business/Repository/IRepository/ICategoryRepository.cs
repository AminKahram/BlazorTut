using Ecommers.DTO.Models.Category;

namespace Ecommers.Business.Repository.IRepository;

public interface ICategoryRepository
{
    Task<CategoryDTO> Create(CategoryDTO addModel);
    Task<CategoryDTO> Update(CategoryDTO editModel);
    Task<int> Delete(int CategoryId);
    Task<IEnumerable<CategoryDTO>> GetAll();
    Task<CategoryDTO> GetCategory(int CategoryId);
}
