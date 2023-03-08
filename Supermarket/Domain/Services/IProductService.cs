using Supermarket.Domain.Models;
using Supermarket.Domain.Services.Communication;

namespace Supermarket.Domain.Services
{
    public interface IProductService
    {
         Task<IEnumerable<Product>> ListAsync();
         Task<ProductResponse> SaveAsync(Product product);
         Task<ProductResponse> UpdateAsync(int id, Product product);
         Task<ProductResponse> DeleteAsync(int id);
    }
}