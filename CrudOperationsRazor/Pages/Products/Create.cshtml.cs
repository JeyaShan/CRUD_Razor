using CrudOperationsRazor.Application.DTOs;
using CrudOperationsRazor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudOperationsRazor.Pages.Products
{
    public class CreateModel : PageModel
    {

        private readonly IProductService _productService;

        public CreateModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductDto Product { get; set; } = new ProductDto();

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _productService.AddProductAsync(Product);
            return RedirectToPage("Index");
        }
        
    }
}
