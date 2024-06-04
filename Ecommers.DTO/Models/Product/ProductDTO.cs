using Ecommers.DTO.Models.Category;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommers.DTO.Models.Product;

public class ProductDTO
{
    public int ID { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    public bool ShowFavorites { get; set; }
    public bool CustomerFavorites { get; set; }
    public string Color { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Required]
    [Range(1, int.MaxValue, ErrorMessage ="Select a category to continue")]
    public int CategoryId { get; set; }
    public CategoryDTO Category { get; set; } = new();
}
