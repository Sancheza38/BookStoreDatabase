using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.SupplierReps
{
    public class CreateModel : SupplierNamePageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public CreateModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            populateSuppliersDropDownList(_context);
            //ViewData["SupplierID"] = new SelectList(_context.Suppliers, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public SupplierRep SupplierRep { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptySupplierRep = new SupplierRep();

            if (await TryUpdateModelAsync<SupplierRep>(emptySupplierRep, "supplierRep", //prefix for form value.
                s => s.Email, s => s.WorkNumber
                , s => s.CellNumber
                , s => s.Fname, s => s.Lname
                , s => s.Organization, s => s.SupplierID))
            {
                _context.SupplierReps.Add(emptySupplierRep);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            populateSuppliersDropDownList(_context, emptySupplierRep.SupplierID);
            return Page();
          /*if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SupplierReps.Add(SupplierRep);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");*/
        }
    }
}
