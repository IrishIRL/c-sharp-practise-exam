using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamWebApp.DAL;
using ExamWebApp.Domain;

namespace ExamWebApp.Pages_UsersIngredients
{
    public class EditModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public EditModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MeasurementId"] = new SelectList(_context.Measurement, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(UsersIngredients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersIngredientsExists(UsersIngredients.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool UsersIngredientsExists(int id)
        {
            return _context.UsersIngredients.Any(e => e.Id == id);
        }
    }
}
