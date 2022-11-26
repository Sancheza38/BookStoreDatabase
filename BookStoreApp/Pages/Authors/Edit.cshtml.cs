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

namespace BookStoreApp.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public EditModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthorOfBooks AuthorOfBooks { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authorofbooks =  await _context.Authors.FirstOrDefaultAsync(m => m.AuthorID == id);
            if (authorofbooks == null)
            {
                return NotFound();
            }
            AuthorOfBooks = authorofbooks;
           ViewData["ContactID"] = new SelectList(_context.Set<AuthorContactDetails>(), "ContactID", "ContactID");
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

            _context.Attach(AuthorOfBooks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorOfBooksExists(AuthorOfBooks.AuthorID))
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

        private bool AuthorOfBooksExists(int id)
        {
          return _context.Authors.Any(e => e.AuthorID == id);
        }
    }
}
