using BookStoreApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookStoreApp.Pages.SupplierReps
{
    public class SupplierNamePageModel : PageModel
    {
        public SelectList SupplierNameSL { get; set; }
        
        public void populateSuppliersDropDownList(StoreContext _context, object selectedSupplier = null)
        {
            var suppliersQuery = from s in _context.Suppliers
                                   orderby s.Fname // sort by First name.
                                   select s;

            SupplierNameSL = new SelectList(suppliersQuery.AsNoTracking(),
                        "ID", "Fname", selectedSupplier);
        }
    }
}
