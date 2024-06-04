using Ecommers.Core.Models.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommers.Core.Models.Products;

public class Product
{
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool ShowFavorites { get; set; }
    public bool CustomerFavorites { get; set; }
    public string Color { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;  
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public Category Category { get; set; } = new();
}
