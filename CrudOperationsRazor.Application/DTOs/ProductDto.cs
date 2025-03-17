using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsRazor.Application.DTOs
{
    public class ProductDto
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        public string Name { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be 0 or positive.")]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Stock Quantity must be 0 or positive.")]
        public int StockQuantity { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
