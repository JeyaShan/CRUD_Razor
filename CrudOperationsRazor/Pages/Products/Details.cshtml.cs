using CrudOperationsRazor.Application.DTOs;
using CrudOperationsRazor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudOperationsRazor.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;
        public DetailsModel(IProductService productService)
        {
             _productService = productService;
        }
        public ProductDto Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productService.GetProductDetailsAsync(id);
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
