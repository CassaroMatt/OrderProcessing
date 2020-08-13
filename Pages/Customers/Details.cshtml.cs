using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OrderProcessing.Data;
using OrderProcessing.Models;

namespace OrderProcessing.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly OrderProcessing.Data.OrderProcessingContext _context;

        public DetailsModel(OrderProcessing.Data.OrderProcessingContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //add below
            //Query that gets id
            //Customer = await _context.Customer.FirstOrDefaultAsync(m => m.ID == id);

            //get each customers order
            Customer = await _context.Customer
            //orders is ICollection
            .Include(o => o.Orders)
            .ThenInclude(p => p.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);


            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
