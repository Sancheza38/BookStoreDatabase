using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public EditModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Customer Customers { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers =  await _context.Customers.FirstOrDefaultAsync(m => m.CustomerID == id);
            
            if (customers == null)
            {
                return NotFound();
            }
            Customers = customers;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var customerToUpdate = await _context.Customers.FindAsync(id);

            if (customerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Customer>(
                customerToUpdate,
                "customers",
                c => c.Fname, c => c.Lname))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
