using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderProcessing.Data;
using OrderProcessing.Models;

namespace OrderProcessing.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly OrderProcessing.Data.OrderProcessingContext _context;

        public CreateModel(OrderProcessing.Data.OrderProcessingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "AName");
        ViewData["EmployeeID"] = new SelectList(_context.Employee, "ID", "Name");
        ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}