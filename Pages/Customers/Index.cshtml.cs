using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrderProcessing.Data;
using OrderProcessing.Models;

namespace OrderProcessing.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly OrderProcessing.Data.OrderProcessingContext _context;

        public IndexModel(OrderProcessing.Data.OrderProcessingContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList States { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CustomerState { get; set; }



        public async Task OnGetAsync()
        {

            // Use LINQ to get list of genres.
            IQueryable<string> stateQuery = from c in _context.Customer
                                            orderby c.State
                                            select c.State;






            //Customer = await _context.Customer.ToListAsync();

            //returns a customer name in the list of customers if not empty

            var customers = from m in _context.Customer
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                customers = customers.Where(s => s.AName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(CustomerState))
            {
                customers = customers.Where(x => x.State == CustomerState);
            }
            States = new SelectList(await stateQuery.Distinct().ToListAsync());

            Customer = await customers.ToListAsync();




        }
    }
}
