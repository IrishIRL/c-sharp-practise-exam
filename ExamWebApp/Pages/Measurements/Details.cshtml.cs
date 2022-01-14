using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ExamWebApp.DAL;
using ExamWebApp.Domain;

namespace ExamWebApp.Pages_Measurements
{
    public class DetailsModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public DetailsModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public Measurement Measurement { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Measurement = await _context.Measurement.FirstOrDefaultAsync(m => m.Id == id);

            if (Measurement == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
