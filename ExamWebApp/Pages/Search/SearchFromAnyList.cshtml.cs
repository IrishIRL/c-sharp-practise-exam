using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamWebApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApp.Pages.Search
{
    public class SearchFromAnyList : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;
        
        public SearchFromAnyList(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }
        public List<Domain.UsersIngredients> UsersIngredients { get; set; } = default!;
        public IList<RecipeIngredient> RecipeIngredient { get; set; } = default!;
        public IList<Recipe> Recipe { get; set; } = default!;

        [BindProperty(SupportsGet = true)] public string SearchString { get; set; } = default!;

        [BindProperty(SupportsGet = true)] public string FoodItems { get; set; } = default!;
        [BindProperty(SupportsGet = true)] public bool Exclude { get; set; } = default!;
        
/*
        public async Task OnGetAsync(int? id, string SearchString)
        {
            Recipe = await _context.Recipes.ToListAsync();
            
            if (id != null)
            {
                RecipeIngredient = await _context.RecipeIngredients
                    .Include(r => r.Ingredient)
                    .Include(r => r.Recipe).ToListAsync();

                Recipe = await _context.Recipes.ToListAsync();
                
            }
        }
  */      
        public async Task OnGetAsync()
        {
            var category = from m in _context.Recipes
                select m;
            //var itemName = from i in _context.RecipeIngredients
            //    select i;
            
            var description = from m in _context.Recipes
                select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                if (Exclude)
                {
                    category = category.Where(s => !s.Category.Contains(SearchString));
                }
                else
                {
                    category = category.Where(s => s.Category.Contains(SearchString));
                }
                //itemName = itemName.Where(s => s.Ingredient!.IngredientName.Contains(SearchString));
            }

            Recipe = await category.ToListAsync();
            //_context.RecipeIngredients.Find(itemName);
            //RecipeIngredient = await itemName.ToListAsync();
        }
        
        public async Task<string> GetIngredient(int id)
        {
            return _context.Recipes.Find(id).ReсipeName;
        }
  
/*
        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from m in _context.Recipes
                orderby m.Category
                select m.Category;

            var ingredients = from m in _context.RecipeIngredients
                select m.Ingredient;

            if (!string.IsNullOrEmpty(SearchString))
            {
                categoryQuery = categoryQuery.Where(s => s!.categoryQuery.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(FoodItems))
            {
                ingredients = ingredients.Where(x => x!.IngredientName == FoodItems);
            }
            Recipe = new SelectList(await categoryQuery.Distinct().ToListAsync());
            FoodItems = await ingredients.ToListAsync();
        }*/
    }
}