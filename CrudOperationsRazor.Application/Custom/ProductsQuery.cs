using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudOperationsRazor.Application.Custom
{
    public class ProductsQuery
    {
        public string Category { get; set; }
        public string SearchTerm { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int PageIndex { get; set; } = 1; 
        public int PageSize { get; set; } = 10; 
    }
}
