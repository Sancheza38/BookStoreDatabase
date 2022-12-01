using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.Shop
{
    public class DetailsModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public DetailsModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

      public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            //var book = await _context.Books.FirstOrDefaultAsync(m => m.ISBN == id);
            var book = await _context.Books
                .Include(s => s.Writes)
                .ThenInclude(e => e.AuthorOfBooks)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ISBN == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
