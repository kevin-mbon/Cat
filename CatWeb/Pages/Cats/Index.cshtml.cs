using CatWeb.Data;
using CatWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatWeb.Pages.Cats
{
    public class IndexModel : PageModel
    {
       private readonly CatDbContext _db;
        public IEnumerable<Cat> Cats { get; set; }
        public IndexModel(CatDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Cats = _db.Cat;
        }
    }
}
