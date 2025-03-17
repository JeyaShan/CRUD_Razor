using CrudOperationsRazor.Application.Custom;
using CrudOperationsRazor.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsRazor.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetPagedProductsAsync(ProductsQuery productsQuery);
        Task<int> GetProductsCountAsync(ProductsQuery productsQuery);
        Task<ProductDto> GetProductDetailsAsync(int id);
        Task AddProductAsync(ProductDto product);
        Task UpdateProductAsync(ProductDto product);
        Task DeleteProductAsync(int id);
    }
}
