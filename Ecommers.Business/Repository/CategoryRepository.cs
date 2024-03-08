using AutoMapper;
using Ecommers.Business.Repository.IRepository;
using Ecommers.Core.Models.Categories;
using Ecommers.DTO.Models.Category;
using Ecommers_DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Ecommers.Business.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDataAccess applicationDataAccess;
    private readonly IMapper mapper;

    public CategoryRepository(ApplicationDataAccess applicationDataAccess,IMapper mapper)
    {
        this.applicationDataAccess = applicationDataAccess;
        this.mapper = mapper;
    }
    public async Task<CategoryDTO> Create(CategoryDTO addModel)
    {
        var category = mapper.Map<CategoryDTO,Category>(addModel);
        
        var objAdd =await applicationDataAccess.AddAsync(category);
        await applicationDataAccess.SaveChangesAsync();
        return mapper.Map<Category, CategoryDTO>(objAdd.Entity);
    }

    public async Task<int> Delete(int CategoryId)
    {
        var categoryQ =await applicationDataAccess.Categories.FirstOrDefaultAsync(c =>c.CategoryId == CategoryId);
        if (categoryQ != null)
        {
            applicationDataAccess.Categories.Remove(categoryQ);
            await applicationDataAccess.SaveChangesAsync();   
            return categoryQ.CategoryId;
        }
        return 0;
        //throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryDTO>> GetAll()
    {
        var categoryQ = await applicationDataAccess.Categories.Select(c => c).ToListAsync();
        if (categoryQ != null)
            return mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDTO>>(categoryQ);

        return Enumerable.Empty<CategoryDTO>();
    }

    public async Task<CategoryDTO> GetCategory(int CategoryId)
        => mapper.Map<Category, CategoryDTO>(await applicationDataAccess.Categories.FirstOrDefaultAsync(c => c.CategoryId == CategoryId) ?? new Category());
    

    public async Task<CategoryDTO> Update(CategoryDTO editModel)
    {
        var categoryQ = await applicationDataAccess.Categories.FirstOrDefaultAsync(c => c.CategoryId == editModel.CategoryId);
        if (categoryQ != null)
        {
            categoryQ.Name = editModel.Name;
            applicationDataAccess.Update(categoryQ);
            await applicationDataAccess.SaveChangesAsync();
            return mapper.Map<Category, CategoryDTO>(categoryQ);
        }
        return editModel;
    }
}
