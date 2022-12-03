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
using BookStoreApp.Pages.Shop;

namespace BookStoreApp.Pages.Cart
{
    public class AddOrderModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        public AddOrderModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; } = new Models.Order();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order =  await _context.Orders.FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            //Sets Order model values
            
            decimal sum = _context.OrderItem
                        .Where(o => o.OrderID == order.OrderID)
                        .Sum(s => s.ItemPrice);
            DateTime dateTime = DateTime.UtcNow.Date;
            Order.OrderValue= sum;
            Order.OrderDate = dateTime.ToString("d");
            Order.OrderID = (int)id;
            Order.CustomerID = order.CustomerID;
           
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

                
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.OrderID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //resets the current order
            AddCartModel.OrderId = "";

            return RedirectToPage("./Index");
        }

        private bool OrderExists(int id)
        {
          return _context.Orders.Any(e => e.OrderID == id);
        }
    }
}
