using Ecommers.DTO.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace Ecommers.Business.Repository.IRepository;

 public interface IProductRepository
{
    Task<ProductDTO> Create(ProductDTO product);
    Task<bool> Delete(int id);
    Task<ProductDTO> Update(ProductDTO product);
    Task<ProductDTO> Get(int id);
    Task<IEnumerable<ProductDTO>> GetAll();
}
