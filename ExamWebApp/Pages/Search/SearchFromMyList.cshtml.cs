using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamWebApp.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApp.Pages.Search
{
    public class SearchFromMyList : PageModel
    {
        private readonly ExamWebApp.DAL.AppDbContext _context;
        //public User User { get; set; } = default!; 

        public SearchFromMyList(ExamWebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get; set; } = default!;
        public User UserFound { get; set; } = default!;
        public List<Domain.UsersIngredients> UsersIngredients { get;set; } = default!;
        public IList<RecipeIngredient> RecipeIngredient { get;set; } = default!;
        public IList<Recipe> Recipe { get;set; } = default!;
        public List<string> SuitableRecipes = default!;
        public string CurrentList { get; set; } = default!;
        
        public List<bool> ListOfItems = new List<bool>();


        public async Task OnGetAsync(int? id, int amountOfPeople = 1)
        {
            User = await _context.Users.ToListAsync();
            if (id != null)
            {
                UserFound = _context.Users.Find(id);
                var userIngredients = _context.UsersIngredients
                    .Where(usersIngredients => usersIngredients.UserId == id)
                    .Include(u => u.Ingredient)
                    .Include(u => u.User).ToListAsync();
                ;

                UsersIngredients = await userIngredients;

                RecipeIngredient = await _context.RecipeIngredients
                    .Include(r => r.Ingredient)
                    .Include(r => r.Recipe).ToListAsync();

                Recipe = await _context.Recipes.ToListAsync();

                SuitableRecipes = new List<string>();
                foreach (var usersIngredient in UsersIngredients)
                {
                    foreach (var recipeIngredient in RecipeIngredient)
                    {
                        if (usersIngredient.Ingredient == recipeIngredient.Ingredient)
                        {
                            if (usersIngredient.Quantity >= recipeIngredient.Quantity)
                            {
                                string recipeName = recipeIngredient.Recipe?.ReсipeName!;

                                if (!SuitableRecipes.Contains(recipeName)) SuitableRecipes.Add(recipeName);
                            }
                        }
                    }
                }

                string currentRecipe = "";
                int counter = 0;
                
                foreach (var recipe in Recipe)
                {
                    foreach (var suitableRecipe in SuitableRecipes)
                    {
                        if (suitableRecipe == recipe.ReсipeName)
                        {
                            foreach (var recipeIngredient in RecipeIngredient)
                            {
                                if (recipeIngredient.Recipe!.ReсipeName == recipe.ReсipeName)
                                {
                                    if (currentRecipe != recipe.ReсipeName)
                                    {
                                        currentRecipe = recipe.ReсipeName;
                                        counter++;
                                    }
                                    
                                    foreach (var usersIngredient in UsersIngredients)
                                    {
                                        if (recipeIngredient.Ingredient!.IngredientName ==
                                            usersIngredient.Ingredient!.IngredientName) 
                                        {
                                            if (usersIngredient.Quantity >= recipeIngredient.Quantity)
                                            {
                                                if(ListOfItems.Count <= counter) ListOfItems.Add(true);
                                                else ListOfItems[counter] = true;
                                            }
                                            else
                                            {
                                                if(ListOfItems.Count <= counter) ListOfItems.Add(false);
                                                else ListOfItems[counter] = false;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if(ListOfItems.Count <= counter) ListOfItems.Add(false);
                                    else ListOfItems[counter] = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}