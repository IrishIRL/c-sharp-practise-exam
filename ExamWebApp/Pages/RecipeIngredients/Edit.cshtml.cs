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

namespace ExamWebApp.Pages_RecipeIngredients
{
    public class EditModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public EditModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Id");
           ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id");
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

            _context.Attach(RecipeIngredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientExists(RecipeIngredient.Id))
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

        private bool RecipeIngredientExists(int id)
        {
            return _context.RecipeIngredients.Any(e => e.Id == id);
        }
        public async Task<string> GetMeasurement(int id)
        {
            return _context.Measurement.Find(id).MeasurementName;
        }
    }
}
