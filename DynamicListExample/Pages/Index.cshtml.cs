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
    public class IndexModel : PageModel
    {
        private readonly DynamicListExample.Data.ApplicationDbContext _context;

        public IndexModel(DynamicListExample.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Parent> Parent { get;set; }

        public async Task OnGetAsync()
        {
            Parent = await _context.Parents.ToListAsync();
        }
    }
}
