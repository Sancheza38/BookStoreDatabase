using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public IndexModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Customer).ToListAsync();
            }
        }
    }
}
