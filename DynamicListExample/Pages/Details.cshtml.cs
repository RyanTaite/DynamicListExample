using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DynamicListExample.Models;

namespace DynamicListExample.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly DynamicListExample.Data.ApplicationDbContext _context;

        public DetailsModel(DynamicListExample.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Parent Parent { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parent = await _context.Parents
                .AsNoTracking()
                .Include(p => p.Children)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Parent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
