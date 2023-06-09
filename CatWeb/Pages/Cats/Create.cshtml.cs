using CatWeb.Data;
using CatWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatWeb.Pages.Cats
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public readonly CatDbContext _db;
        
        public Cat Cat { get; set; }
       
        public CreateModel(CatDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                await _db.Cat.AddAsync(Cat);
                await _db.SaveChangesAsync();
                TempData["success"] = "Cat Added successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
