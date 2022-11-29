using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Pages.BrowseBooks
{
    public class IndexModel : PageModel
    {
        private readonly BookStoreApp.Data.StoreContext _context;
        // public int TestVar = 1;

            public IList<Models.Book> BooksFound { get; set; } = new List<Models.Book>();
            [BindProperty]
            public Models.Book BooksParam { get; set; }

            public IndexModel(BookStoreApp.Data.StoreContext context)
            {
                _context = context;
            }

            public IActionResult OnGet()
            {
                return Page();
            }




        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
            public void OnPost()
            {
               /* if (!ModelState.IsValid)
                {
                    return Page();
                }*/

                var ISBN =new SqlParameter("ISBN", "" + BooksParam.ISBN);
                var Title = new SqlParameter("Title", BooksParam.Title);
                var PublicationDate = new SqlParameter("PublicationDate", BooksParam.PublicationDate.ToString());
                var Price = new SqlParameter("Price", "" + BooksParam.Price);
                var UserReview = new SqlParameter("UserReview", "" + BooksParam.UserReview);
                List<Models.Book> booksFound = _context.Books
                                          .FromSql($"SELECT * FROM dbo.Book WHERE ISBN = {ISBN} OR Title = {Title} OR PublicationDate = {PublicationDate} OR Price = {Price} OR UserReview = {UserReview};")
                                          .ToList();
                BooksFound = booksFound;
                BooksParam = new Models.Book();
                Console.WriteLine("Yppppppppp");
                /*if(booksFound.Count > 0) {
                   // TestVar = 0;
                    
                    foreach (Models.Book item in booksFound){
                        Console.WriteLine("YOOOOOOO");
                        Console.WriteLine(item.ISBN);
                        BooksFound.ISBN = item.ISBN;
                        BooksFound.Title = item.Title;
                        BooksFound.UserReview = item.UserReview;
                        BooksFound.Price = item.Price;
                        BooksFound.PublicationDate= item.PublicationDate;
                        Console.WriteLine(BooksFound.Title);
                    }
                }
                 else
                 {
                BooksFound = null;
                 }*/

            // _context.Books.Add(BooksFound);
            //return Page();
            Redirect("/BrowseBooks/Index");

            }
    }
}
