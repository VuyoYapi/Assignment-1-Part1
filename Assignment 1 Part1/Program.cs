using Assignment_1_Part1;
using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();  // Store multiple recipes
            double[] originalQuantities = null;

            while (true)
            {
                Console.WriteLine("\nRecipe Application");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Display a specific recipe");
                Console.WriteLine("4. Scale a recipe");
                Console.WriteLine("5. Reset quantities of a recipe");
                Console.WriteLine("6. Clear a recipe");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Enter a new recipe
                        Console.Write("Enter the recipe name: ");
                        string recipeName = Console.ReadLine();
                        Recipe recipe = new Recipe(recipeName);
                        recipes.Add(recipe);

                        Console.Write("Enter the number of ingredients: ");
                        int ingredientCount = int.Parse(Console.ReadLine());
                        originalQuantities = new double[ingredientCount];

                        for (int i = 0; i < ingredientCount; i++)
                        {
                            Console.Write("Enter ingredient name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter quantity: ");
                            double quantity = double.Parse(Console.ReadLine());
                            Console.Write("Enter unit of measurement: ");
                            string unit = Console.ReadLine();
                            Console.Write("Enter number of calories: ");
                            int calories = int.Parse(Console.ReadLine());
                            Console.Write("Enter food group: ");
                            string foodGroup = Console.ReadLine();
                            recipe.Ingredients.Add(new Ingredient(name, quantity, unit, calories, foodGroup));
                            originalQuantities[i] = quantity;
                        }

                        Console.Write("Enter the number of steps: ");
                        int stepCount = int.Parse(Console.ReadLine());

                        for (int i = 0; i < stepCount; i++)
                        {
                            Console.Write("Enter step description: ");
                            string step = Console.ReadLine();
                            recipe.Steps.Add(step);
                        }

                        // Subscribe to calorie notifications
                        recipe.CalorieNotification += (message) => Console.WriteLine(message);

                        break;

                    case "2":
                        // Display all recipes sorted alphabetically
                        var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
                        Console.WriteLine("\nRecipes:");
                        foreach (var r in sortedRecipes)
                        {
                            Console.WriteLine(r.Name);
                        }
                        break;

                    case "3":
                        // Display a specific recipe
                        Console.Write("Enter the name of the recipe to display: ");
                        string displayRecipeName = Console.ReadLine();
                        Recipe displayRecipe = recipes.FirstOrDefault(r => r.Name.Equals(displayRecipeName, StringComparison.OrdinalIgnoreCase));
                        if (displayRecipe != null)
                        {
                            displayRecipe.DisplayRecipe();
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;

                    case "4":
                        // Scale a recipe
                        Console.Write("Enter the name of the recipe to scale: ");
                        string scaleRecipeName = Console.ReadLine();
                        Recipe scaleRecipe = recipes.FirstOrDefault(r => r.Name.Equals(scaleRecipeName, StringComparison.OrdinalIgnoreCase));
                        if (scaleRecipe != null)
                        {
                            Console.WriteLine("Enter scale factor (0.5 for half, 2 for double, 3 for triple): ");
                            double factor = double.Parse(Console.ReadLine());
                            scaleRecipe.ScaleRecipe(factor);
                            Console.WriteLine("Recipe scaled.");
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;

                    case "5":
                        // Reset quantities of a recipe
                        Console.Write("Enter the name of the recipe to reset quantities: ");
                        string resetRecipeName = Console.ReadLine();
                        Recipe resetRecipe = recipes.FirstOrDefault(r => r.Name.Equals(resetRecipeName, StringComparison.OrdinalIgnoreCase));
                        if (resetRecipe != null)
                        {
                            resetRecipe.ResetQuantities(originalQuantities);
                            Console.WriteLine("Quantities reset to original values.");
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;

                    case "6":
                        // Clear a recipe
                        Console.Write("Enter the name of the recipe to clear: ");
                        string clearRecipeName = Console.ReadLine();
                        Recipe clearRecipe = recipes.FirstOrDefault(r => r.Name.Equals(clearRecipeName, StringComparison.OrdinalIgnoreCase));
                        if (clearRecipe != null)
                        {
                            clearRecipe.ClearRecipe();
                            Console.WriteLine("Recipe cleared.");
                        }
                        else
                        {
                            Console.WriteLine("Recipe not found.");
                        }
                        break;

                    case "7":
                        // Exit the application
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}