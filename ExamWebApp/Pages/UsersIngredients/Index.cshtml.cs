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
    public class IndexModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public IndexModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<UsersIngredients> UsersIngredients { get;set; } = default!;

        public async Task OnGetAsync()
        {
            UsersIngredients = await _context.UsersIngredients
                .Include(u => u.Ingredient)
                .Include(u => u.User).ToListAsync();
        }
        public async Task<string> GetMeasurement(int id)
        {
            return _context.Measurement.Find(id).MeasurementName;
        }
    }
}
