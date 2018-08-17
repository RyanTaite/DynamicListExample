using System;
using System.Linq;
using System.Threading.Tasks;
using DynamicListExample.Data;
using DynamicListExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DynamicListExample.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
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

            Parent = await _context.Parents
                .Include(p => p.Children)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Parent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Parent parent)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var parentToUpdate = await _context.Parents
                    .Include(p => p.Children)
                    .SingleOrDefaultAsync(p => p.Id == parent.Id);

                if (parentToUpdate == null) return NotFound();

                // Update the Parent's name
                parentToUpdate.Name = parent.Name;

                // Save this to a list so when we remove something from parentToUpdate, it doesn't 
                // get mad at us for trying to further alter a modified collection
                var existingChildren = parentToUpdate.Children?.ToList();
                
                // Deteach Children from the Call Detail if they don't show up now
                if (existingChildren != null)
                {
                    foreach (var child in existingChildren)
                    {
                        if (parent.Children.FirstOrDefault(x => x.Id == child.Id) == null)
                        {
                            parentToUpdate.Children.Remove(child);
                        }
                    }
                }

                // Add or Update existing and new Children
                foreach (var child in parent.Children)
                {
                    var childToUpdate = parentToUpdate.Children?.FirstOrDefault(c => c.Id == child.Id);

                    if (childToUpdate != null)
                    {
                        childToUpdate.Name = child.Name;
                    }
                    else
                    {
                        parentToUpdate.Children?.Add(new Child
                        {
                            Name = child.Name,
                            ParentId = parent.Id
                        });
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentExists(Parent.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool ParentExists(Guid id)
        {
            return _context.Parents.Any(e => e.Id == id);
        }
    }
}
