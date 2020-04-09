using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DynamicListExample.Data;
using DynamicListExample.Models;

namespace DynamicListExample.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly DynamicListExample.Data.ApplicationDbContext _context;

        public DeleteModel(DynamicListExample.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parent Parent { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parent = await _context.Parents.FirstOrDefaultAsync(m => m.Id == id);

            if (Parent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Parent = await _context.Parents.FindAsync(id);

            if (Parent != null)
            {
                _context.Parents.Remove(Parent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
