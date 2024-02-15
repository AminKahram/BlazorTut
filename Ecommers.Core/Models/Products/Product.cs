namespace Ecommers.Core.Models.Products;

public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public bool IsActive { get; set; }
    public IEnumerable<ProductsProp> ProductsProps { get; set; }
}
