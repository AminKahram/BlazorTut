using System.ComponentModel.DataAnnotations;

namespace Ecommers.DTO.Models.Category;

public class CategoryDTO
{
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Name must be added")]
    public string Name { get; set; } = string.Empty;
}
