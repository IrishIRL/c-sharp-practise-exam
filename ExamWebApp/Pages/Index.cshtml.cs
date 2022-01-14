using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamWebApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace ExamWebApp.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        /*
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/

        private readonly ExamWebApp.DAL.AppDbContext _context;
        //public User User { get; set; } = default!; 

        public IndexModel(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get; set; } = default!;
        public User UserFound { get; set; } = default!;
        public List<Domain.UsersIngredients> UsersIngredients { get;set; } = default!;

        //public Ingredient Ingredients { get; set; } = default!;
        //public UsersIngredients UsersIngredientsFound { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {
            User = await _context.Users.ToListAsync();
            if (id != null)
            {
                UserFound = _context.Users.Find(id);
                var userIngredients = _context.UsersIngredients.Where(usersIngredients => usersIngredients.UserId == id).Include(u => u.Ingredient)
                    .Include(u => u.User).ToListAsync();;
                UsersIngredients = await userIngredients;
            }
        }
        
        public async Task<string> GetMeasurement(int id)
        {
            return _context.Measurement.Find(id).MeasurementName;
        }
    }
}