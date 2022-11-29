using BookStoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreApp.Pages
{
    public class RegisterModel : PageModel
    {
        public Register Model { get; set; }
        public void OnGet()
        {
        }
    }
}
