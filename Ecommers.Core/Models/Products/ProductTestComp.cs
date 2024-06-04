using Ecommers.Core.Models.Categories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommers.Core.Models.Products;

public class ProductTestComp
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
     public bool IsActive { get; set; }

    public IEnumerable<ProductsProp> ProductsProps { get; set; }= [];
}
