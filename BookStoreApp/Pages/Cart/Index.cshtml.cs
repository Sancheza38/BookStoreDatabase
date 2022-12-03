using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;
using BookStoreApp.Pages.Shop;

namespace BookStoreApp.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public IndexModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        public IList<OrderItem> OrderItem { get;set; } = default!;
        public int orderId;

        public async Task OnGetAsync()
        {
            
             var customer = _context.Customers
                           .Where(c => c.Username == User.Identity.Name)
                           .FirstOrDefault();

            if (_context.OrderItem != null && AddCartModel.OrderId != "")
            {
                OrderItem = await _context.OrderItem
                .Include(o => o.Books)
                .Include(o => o.Orders)
                .Where(o => o.Orders.CustomerID == customer.CustomerID)
                .Where(o => o.OrderID == Int32.Parse(AddCartModel.OrderId))
                .ToListAsync();
                orderId= Int32.Parse(AddCartModel.OrderId);
            }
        }
    }
}
