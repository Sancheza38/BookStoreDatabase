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
            if (id == null)
            {
                return NotFound();
            }

            var books = await _context.Books.FirstOrDefaultAsync(m => m.ISBN == id);
                
            if (books == null)
            {
                return NotFound();
            }
            Books = books;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(long id)
        {
            var bookToUpdate = await _context.Books.FindAsync(id);

            if (bookToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Book>(
                bookToUpdate,
                "books",
                s => s.Title, s => s.Price, s => s.UserReview, s => s.PublicationDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
