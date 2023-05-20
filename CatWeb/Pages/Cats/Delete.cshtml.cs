using CatWeb.Data;
using CatWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatWeb.Pages.Cats
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public readonly CatDbContext _db;

        public Cat Cat { get; set; }
        public DeleteModel(CatDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)   
        {
           Cat = _db.Cat.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var catFromDb = _db.Cat.Find(Cat.Id);
           if(catFromDb != null)
            {
                _db.Cat.Remove(catFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Cat deleted seccessfully";
                return RedirectToPage("Index");

            }
            return Page();
        }

    }
}
