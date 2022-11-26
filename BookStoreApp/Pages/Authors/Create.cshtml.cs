using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.Authors
{
    public class CreateModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public CreateModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ContactID"] = new SelectList(_context.Set<AuthorContactDetails>(), "ContactID", "ContactID");
            return Page();
        }

        [BindProperty]
        public AuthorOfBooks AuthorOfBooks { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Authors.Add(AuthorOfBooks);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
