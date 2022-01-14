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
    public class DeleteModel : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;

        public DeleteModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Measurement Measurement { get; set; }= default!;

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Measurement = await _context.Measurement.FindAsync(id);

            if (Measurement != null)
            {
                _context.Measurement.Remove(Measurement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
