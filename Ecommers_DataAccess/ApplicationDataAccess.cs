using Ecommers.Core.Models.Categories;
using Ecommers.Core.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace Ecommers_DataAccess;

public class ApplicationDataAccess:DbContext
{
    public ApplicationDataAccess(DbContextOptions<ApplicationDataAccess> dbContextOptions):base(dbContextOptions)
    {
        
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}
