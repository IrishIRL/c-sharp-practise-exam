using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExamWebApp.DAL;
using ExamWebApp.Domain;

namespace ExamWebApp.Pages_Recipes
{
    public class IndexModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public IndexModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes.ToListAsync();
        }
    }
}
