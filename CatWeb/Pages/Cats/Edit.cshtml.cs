using CatWeb.Data;
using CatWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatWeb.Pages.Cats
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public readonly CatDbContext _db;
        
        public Cat Cat { get; set; }
       
        public EditModel(CatDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Cat = _db.Cat.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                 _db.Cat.Update(Cat);
                await _db.SaveChangesAsync();
                TempData["success"] = "Cat Updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
