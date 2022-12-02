using Azure.Identity;
using BookStoreApp.Data;
using BookStoreApp.Models;
using BookStoreApp.Pages.Customers;
using BookStoreApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly StoreContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;

        [BindProperty]
        public Register Model { get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, StoreContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _db = db;
            _roleManager = roleManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email
                };

                var customer = new Customer()
                {
                    Username = Model.Email,
                    Fname = Model.Fname,
                    Lname = Model.Lname
                };

                await _db.Customers.AddAsync(customer);
                await _db.SaveChangesAsync();
                
                var result = await userManager.CreateAsync(user, Model.Password);
                if (result.Succeeded)
                {
                    var defaultrole = _roleManager.FindByNameAsync("CustomerRole").Result;
                    if (defaultrole != null)
                    {
                        IdentityResult roleresult = await userManager.AddToRoleAsync(user, "CustomerRole");
                    }    
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return Page();
        }
    }
}
