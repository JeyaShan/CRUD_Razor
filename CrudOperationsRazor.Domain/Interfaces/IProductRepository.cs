using CrudOperationsRazor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsRazor.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(string category, string searchTerm, decimal? minPrice, decimal? maxPrice, int pageIndex, int pageSize);
        Task<int> CountAsync(string category, string searchTerm, decimal? minPrice, decimal? maxPrice);
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
