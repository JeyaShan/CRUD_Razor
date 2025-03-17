using CrudOperationsRazor.Application.DTOs;
using CrudOperationsRazor.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudOperationsRazor.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _productService;

        public DeleteModel(IProductService productService)
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
            if (Product == null || Product.Id <= 0)
            {
                return NotFound();
            }

            try
            {
                await _productService.DeleteProductAsync(Product.Id);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error deleting product.");
                return Page();
            }
            return RedirectToPage("./Index");
        }

         



    }
    }
