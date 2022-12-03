using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.SupplierReps
{
    public class DetailsModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public DetailsModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

      public SupplierRep SupplierRep { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.SupplierReps == null)
            {
                return NotFound();
            }

            var supplierrep = await _context.SupplierReps.FirstOrDefaultAsync(m => m.Email == id);
            if (supplierrep == null)
            {
                return NotFound();
            }
            else 
            {
                SupplierRep = supplierrep;
            }
            return Page();
        }
    }
}
