using AutoMapper;
using Ecommers.Business.Repository.IRepository;
using Ecommers.Core.Models.Products;
using Ecommers.DTO.Models.Product;
using Ecommers_DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Ecommers.Business.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDataAccess ApplicationData;
    private readonly IMapper Mapper;

    public ProductRepository(ApplicationDataAccess applicationData, IMapper mapper)
    {
        this.ApplicationData = applicationData;
        this.Mapper = mapper;
    }
    public async Task<ProductDTO> Create(ProductDTO product)
    {
        try
        {
            var result = await ApplicationData.AddAsync(Mapper.Map<ProductDTO, Product>(product));
            await ApplicationData.SaveChangesAsync();
            return Mapper.Map<Product, ProductDTO>(result.Entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProductDTO> Get(int id)
        => Mapper.Map<Product, ProductDTO>(await ApplicationData.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ID == id) ?? new Product());

    public async Task<IEnumerable<ProductDTO>> GetAll()
        => Mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(await ApplicationData.Products.Include(p => p.Category).ToListAsync());

    public async Task<bool> Delete(int id)
    {
        try
        {
            var peoductQ = await ApplicationData.Products.FirstOrDefaultAsync(q => q.ID == id);
            if (peoductQ != null)
            {
                var prod = ApplicationData.Products.Remove(peoductQ);
                await ApplicationData.SaveChangesAsync();

                if (prod != null)
                    return true;
                return false;
            }
            return false;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<ProductDTO> Update(ProductDTO product)
    {
        try
        {
            var productQ = await ApplicationData.Products.FirstOrDefaultAsync(q => q.ID == product.ID);
            if (productQ != null)
            {
                productQ.Name = product.Name;
                var result = ApplicationData.Products.Update(productQ) ; 
                await ApplicationData.SaveChangesAsync();
                return Mapper.Map<Product, ProductDTO>(result.Entity);
            }
            return new ProductDTO();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
