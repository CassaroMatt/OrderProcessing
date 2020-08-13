using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderProcessing.Data;
using OrderProcessing.Models;

namespace OrderProcessing.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly OrderProcessing.Data.OrderProcessingContext _context;

        public IndexModel(OrderProcessing.Data.OrderProcessingContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Product.ToListAsync();
        }
    }
}
