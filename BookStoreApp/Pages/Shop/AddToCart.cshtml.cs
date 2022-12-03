using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStoreApp.Data;
using BookStoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApp.Pages.Shop
{

    public class AddCartModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;

        [BindProperty]
        public OrderItem OrderItem { get; set; } = new OrderItem();

   
        public Order Order { get; set; }

        public static String OrderId = "";

        public AddCartModel(BookStoreApp.Data.StoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
          
            var book = await _context.Books
                   .FirstOrDefaultAsync(m => m.ISBN == id);

            var customer = _context.Customers
                           .Where(c => c.Username == User.Identity.Name)
                           .FirstOrDefault();
            
            OrderItem.ISBN = book.ISBN;
            OrderItem.ItemPrice = book.Price;

            
            
            return Page();
        }

        

       
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
            // checks for no id
            if (OrderId == "")
            {
                
                var customer = _context.Customers
                           .Where(c => c.Username == User.Identity.Name)
                           .FirstOrDefault();
                Order = new Order();
                Order.CustomerID = customer.CustomerID;
                _context.Orders.Add(Order);
                await _context.SaveChangesAsync();

                OrderId = (Order.OrderID).ToString();
       
            }

            
            OrderItem.OrderID = Int32.Parse(OrderId);

           
            _context.OrderItem.Add(OrderItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
