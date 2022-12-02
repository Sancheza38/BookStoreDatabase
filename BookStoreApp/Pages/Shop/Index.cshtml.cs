using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.Data;
using BookStoreApp.Models;

namespace BookStoreApp.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private readonly StoreContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(StoreContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string TitleSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentDateFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Book> Books { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter,string currentDateFilter,string searchDateString, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            if (searchDateString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchDateString = currentDateFilter;
            }

            CurrentFilter = searchString;
            CurrentDateFilter = searchDateString;

            IQueryable<Book> booksIQ = from s in _context.Books select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                booksIQ = booksIQ.Where(s =>
                                    s.ISBN.ToString().Contains(searchString)
                                 || s.Title.Contains(searchString)
                                 || s.UserReview.ToString().Contains(searchString)
                                 || s.Price.ToString().Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchDateString))
            {
                booksIQ = booksIQ.Where(s =>
                                    s.PublicationDate.ToString().Contains(searchDateString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    booksIQ = booksIQ.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    booksIQ = booksIQ.OrderBy(s => s.PublicationDate);
                    break;
                case "date_desc":
                    booksIQ = booksIQ.OrderByDescending(s => s.PublicationDate);
                    break;
                default:
                    booksIQ = booksIQ.OrderBy(s => s.Title);
                    break;

            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Books = await PaginatedList<Book>.CreateAsync(
                booksIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

        }
    }
}
