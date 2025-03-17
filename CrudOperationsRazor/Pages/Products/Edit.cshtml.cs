using CrudOperationsRazor.Application.DTOs;
using CrudOperationsRazor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudOperationsRazor.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;

        public EditModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _productService.UpdateProductAsync(Product);
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                ModelState.AddModelError(string.Empty, "An error occurred while updating the product.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
