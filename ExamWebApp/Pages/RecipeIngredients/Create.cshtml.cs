using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamWebApp.DAL;
using ExamWebApp.Domain;

namespace ExamWebApp.Pages_RecipeIngredients
{
    public class CreateModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public CreateModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "Id");
        ViewData["RecipeId"] = new SelectList(_context.Recipes, "Id", "Id");
        ViewData["MeasurementId"] = new SelectList(_context.Measurement, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public RecipeIngredient RecipeIngredient { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RecipeIngredients.Add(RecipeIngredient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        public async Task<string> GetMeasurement(int id)
        {
            return _context.Measurement.Find(id).MeasurementName;
        }
    }
}
