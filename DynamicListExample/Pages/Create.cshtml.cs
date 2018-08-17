using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DynamicListExample.Models;

namespace DynamicListExample.Pages
{
    public class CreateModel : PageModel
    {
        private readonly DynamicListExample.Data.ApplicationDbContext _context;

        [BindProperty]
        public Parent Parent { get; set; }

        public CreateModel(DynamicListExample.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Parents.Add(Parent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}