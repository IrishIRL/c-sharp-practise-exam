using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExamWebApp.DAL;
using ExamWebApp.Domain;

namespace ExamWebApp.Pages_RecipeIngredients
{
    public class DetailsModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public DetailsModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public RecipeIngredient RecipeIngredient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RecipeIngredient = await _context.RecipeIngredients
                .Include(r => r.Ingredient)
                .Include(r => r.Recipe).FirstOrDefaultAsync(m => m.Id == id);

            if (RecipeIngredient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
