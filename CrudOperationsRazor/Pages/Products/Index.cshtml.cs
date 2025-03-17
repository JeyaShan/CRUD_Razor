using CrudOperationsRazor.Application.Custom;
using CrudOperationsRazor.Application.DTOs;
using CrudOperationsRazor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudOperationsRazor.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IEnumerable<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public ProductsQuery ProductsQuery { get; set; } = new ProductsQuery();

        public async Task OnGetAsync()
        {
            // ProductsQuery.PageSize = 2;
            int totalItems = await _productService.GetProductsCountAsync(ProductsQuery);
            Products = await _productService.GetPagedProductsAsync(ProductsQuery);
            TotalPages = (int)Math.Ceiling(totalItems / (double)ProductsQuery.PageSize);
        }
        
    }
}
