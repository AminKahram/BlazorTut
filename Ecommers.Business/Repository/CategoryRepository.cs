using AutoMapper;
using Ecommers.Business.Repository.IRepository;
using Ecommers.Core.Models.Categories;
using Ecommers.DTO.Models.Category;
using Ecommers_DataAccess;
using Ecommers_DataAccess.Migrations;

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
    public CategoryDTO Create(CategoryDTO addModel)
    {
        var category = mapper.Map<CategoryDTO,Category>(addModel);
        
        var objAdd = applicationDataAccess.Add(category);
        applicationDataAccess.SaveChanges();
        return mapper.Map<Category, CategoryDTO>(objAdd.Entity);
    }

    public int Delete(int CategoryId)
    {
        var categoryQ = applicationDataAccess.Categories.FirstOrDefault(c =>c.CategoryId == CategoryId);
        if (categoryQ != null)
        {
            applicationDataAccess.Categories.Remove(categoryQ);
            return categoryQ.CategoryId;
        }
        return 0;
        //throw new NotImplementedException();
    }

    public IEnumerable<CategoryDTO> GetAll()
    {
        var categoryQ = applicationDataAccess.Categories.Select(c => c).ToList();
        if (categoryQ != null)
            return mapper.Map<IEnumerable<Category>,IEnumerable<CategoryDTO>>(categoryQ);

        return Enumerable.Empty<CategoryDTO>();
        //throw new NotImplementedException();
    }

    public CategoryDTO GetCategory(int CategoryId)
    {
        return mapper.Map<Category, CategoryDTO>(applicationDataAccess.Categories.FirstOrDefault(c => c.CategoryId == CategoryId)?? new Category());
        //throw new NotImplementedException();
    }

    public CategoryDTO Update(CategoryDTO editModel)
    {
        var categoryQ = applicationDataAccess.Categories.FirstOrDefault(c => c.CategoryId == editModel.CategoryId);
        if (categoryQ != null)
        {
            categoryQ.Name = editModel.Name;
            applicationDataAccess.Update(categoryQ);
            applicationDataAccess.SaveChanges();
            return mapper.Map<Category, CategoryDTO>(categoryQ);

        }
        return editModel;
        //throw new NotImplementedException();
    }
}
