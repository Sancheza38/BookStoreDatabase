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

namespace BookStoreApp.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public EditModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Book Books { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var books =  await _context.Books.FirstOrDefaultAsync(m => m.ISBN == id);
            if (books == null)
            {
                return NotFound();
            }
            Books = books;
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

            _context.Attach(Books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(Books.ISBN))
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

        private bool BooksExists(long id)
        {
          return _context.Books.Any(e => e.ISBN == id);
        }
    }
}
