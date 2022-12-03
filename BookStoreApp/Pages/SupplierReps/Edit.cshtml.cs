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

namespace BookStoreApp.Pages.SupplierReps
{
    public class EditModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public EditModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SupplierRep SupplierRep { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.SupplierReps == null)
            {
                return NotFound();
            }

            var supplierrep =  await _context.SupplierReps.FirstOrDefaultAsync(m => m.Email == id);
            if (supplierrep == null)
            {
                return NotFound();
            }
            SupplierRep = supplierrep;
           ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SupplierRep).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierRepExists(SupplierRep.Email))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SupplierRepExists(string id)
        {
          return _context.SupplierReps.Any(e => e.Email == id);
        }
    }
}
