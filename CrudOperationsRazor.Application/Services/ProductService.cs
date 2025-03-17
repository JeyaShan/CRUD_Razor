using CrudOperationsRazor.Application.Custom;
using CrudOperationsRazor.Application.DTOs;
using CrudOperationsRazor.Application.Interfaces;
using CrudOperationsRazor.Domain.Entities;
using CrudOperationsRazor.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsRazor.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        
        public async Task<IEnumerable<ProductDto>> GetPagedProductsAsync(ProductsQuery productsQuery)
        {
            try
            {
                
                var products = await _productRepository.GetAllAsync(productsQuery.Category, productsQuery.SearchTerm, productsQuery.MinPrice, productsQuery.MaxPrice, productsQuery.PageIndex, productsQuery.PageSize);

                var productData = products.Select(p => new ProductDto
                {
                     Category =p.Category,
                     Description =p.Description,
                     Id = p.Id,
                     Name= p.Name,
                     Price =p.Price,
                     StockQuantity = p.StockQuantity
                });

                return productData;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error fetching paged products.", ex);
            }
        }

        public async Task<int> GetProductsCountAsync(ProductsQuery productsQuery)
        {
              return await _productRepository.CountAsync(productsQuery.Category,productsQuery.SearchTerm,productsQuery.MinPrice,productsQuery.MaxPrice);
        }


        public async Task<ProductDto> GetProductDetailsAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            return MapToDto(product);
        }

        
        public async Task AddProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity,
                Category = productDto.Category
            };

            await _productRepository.AddAsync(product);
        }

       
        public async Task UpdateProductAsync(ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productDto.Id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {productDto.Id} not found.");

            
            existingProduct.Name = productDto.Name;
            existingProduct.Description = productDto.Description;
            existingProduct.Price = productDto.Price;
            existingProduct.StockQuantity = productDto.StockQuantity;
            existingProduct.Category = productDto.Category;

            await _productRepository.UpdateAsync(existingProduct);
        }

        
        public async Task DeleteProductAsync(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            await _productRepository.DeleteAsync(existingProduct.Id);
        }

        
        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category
            };
        }
    }
}
