using AbyWeb.Data;
using AbyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Used if multiple prorerties need binding in the future.
//[BindProperties]
namespace AbyWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(string.Empty, "The Display Name value cannot exactly match the Name value.");
            }

            if(ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Your Category has been updated!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
