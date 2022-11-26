using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public DetailsModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

      public AuthorOfBooks AuthorOfBooks { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authorofbooks = await _context.Authors.FirstOrDefaultAsync(m => m.AuthorID == id);
            if (authorofbooks == null)
            {
                return NotFound();
            }
            else 
            {
                AuthorOfBooks = authorofbooks;
            }
            return Page();
        }
    }
}
