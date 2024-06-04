namespace Ecommers.Core.Models.Categories;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; } = DateTime.Now;
}
