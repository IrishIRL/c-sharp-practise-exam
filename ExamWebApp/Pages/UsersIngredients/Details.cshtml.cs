using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExamWebApp.DAL;
using ExamWebApp.Domain;

namespace ExamWebApp.Pages_UsersIngredients
{
    public class DetailsModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public DetailsModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public UsersIngredients UsersIngredients { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UsersIngredients = await _context.UsersIngredients
                .Include(u => u.Ingredient)
                .Include(u => u.User).FirstOrDefaultAsync(m => m.Id == id);

            if (UsersIngredients == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
