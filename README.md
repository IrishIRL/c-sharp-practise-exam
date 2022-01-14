# C# - Practise exam
## Task: Meal Planner - WebApp (Razor Pages)

Make a system to show to user what meals he/she could curently prepare. Keep track of products currently in hand (category, location, amount). Manage recipes (ingredients, amounts needed, servings, category, time needed). Allow user to select servings currently needed (ie, how many people want to eat currently) (recalculate recipe ingredient amounts), time at hand and show what could possible be made - based on suitable recipes and existing ingredients. Allow filtering/ searching (positive and negative) - ie show me meals which can be made in max 36 minutes, containing tomatoes - but not containing pasta.

Generally speaking - these are only broad guidelines. Please write a solution, that you would like to present to the world as your best effort in programming and app-designing (UX is the key).

To be implemented as Razor Pages based Web App. No ViewBags! Nullable Reference Types have to be enabled solution wide.


## Time limits
~~~
Start: 10:00 (Actual: 11:00)
End: 21:00 (Actual: 22:00)
~~~

## Final result
~~~
Grade: 30/30
~~~

## Other stuff

#### Scaffolding
~~~
dotnet ef migrations --project ExamWebApp --startup-project ExamWebApp  add Initial
dotnet ef database --project ExamWebApp --startup-project ExamWebApp update
~~~

~~~
dotnet aspnet-codegenerator razorpage -m Ingredient -outDir Pages/Ingredients -dc AppDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m Recipe -outDir Pages/Recipes -dc AppDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m RecipeIngredient -outDir Pages/RecipeIngredients -dc AppDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m User -outDir Pages/Users -dc AppDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m Measurement -outDir Pages/Measurements -dc AppDbContext -udl --referenceScriptLibraries -f
dotnet aspnet-codegenerator razorpage -m UsersIngredients -outDir Pages/UsersIngredients -dc AppDbContext -udl --referenceScriptLibraries -f
~~~
