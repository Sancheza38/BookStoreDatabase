using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public DeleteModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Models.Book Books { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            //var books = await _context.Books.FirstOrDefaultAsync(m => m.ISBN == id);
            var books = await _context.Books
                .Include(s => s.Writes)
                .ThenInclude(e => e.AuthorOfBooks)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ISBN == id);

            if (books == null)
            {
                return NotFound();
            }
            else 
            {
                Books = books;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var books = await _context.Books.FindAsync(id);

            if (books != null)
            {
                Books = books;
                _context.Books.Remove(Books);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
