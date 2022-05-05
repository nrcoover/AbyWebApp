using AbyWeb.Data;
using AbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Used if multiple prorerties need binding in the future.
//[BindProperties]
namespace AbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Categories.Find(id);
            //Category = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category = _db.Categories.SingleOrDefault(u => u.Id == id);
            //Category = _db.Categories.Where(u => u.Id == id).FirstOrDefault();
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _db.Categories.Find(Category.Id);
            if(categoryFromDb != null)
            {
                _db.Categories.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Your Category has been deleted!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
