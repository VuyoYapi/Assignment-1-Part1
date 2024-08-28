This project is a standalone command-line application developed in C# using Visual Studio. The application allows users to create and manage a single recipe by entering details such as ingredients and preparation steps. The key features of the application include:

Adding a Recipe: Users can input the number of ingredients and steps for a recipe. For each ingredient, the user specifies the name, quantity, and unit of measurement. For each step, the user provides a description of the action.

Displaying a Recipe: The application neatly displays the full recipe, including all ingredients and steps.

Scaling the Recipe: Users can scale the recipe by a factor of 0.5 (half), 2 (double), or 3 (triple). The application adjusts the quantities of all ingredients accordingly.

Resetting Quantities: Users can reset all ingredient quantities to their original values after scaling.

Clearing the Recipe: Users have the option to clear all entered data, allowing them to start fresh with a new recipe.

In-Memory Storage: All data is stored in memory, meaning it is not persisted between application runs.

The application is designed following standard coding practices, using classes and methods to ensure modularity and reusability. It uses arrays to store ingredients and steps, and thorough commenting is included to explain the code structure and logic. The project is version-controlled using GitHub, with regular commits to track development progress.
![Project screenshot 1](https://github.com/user-attachments/assets/a644f635-0ec0-4053-b9c5-52b2ea6d94ff)
![First tag for the project](https://github.com/user-attachments/assets/d12bc99e-4309-4358-abee-a1d78372bd8b)

To extend the application from Part 1 to include the new requirements for Part 2, we will make several enhancements. The updated application will now manage multiple recipes, provide additional nutritional information for ingredients, and allow users to view recipes in alphabetical order. We will also implement delegates to calculate total calories and notify the user if the recipe exceeds 300 calories.

Updated Implementation Plan
1. Enhance the Ingredient and Recipe Classes
We will add new properties to the Ingredient class for calories and food groups. We will also modify the Recipe class to calculate total calories and handle multiple recipes.

2. Implement a Generic Collection for Storing Recipes
Instead of using arrays, we will use a generic collection (List<T>) to store an unlimited number of recipes. This allows for dynamic resizing and easy management of recipe data.

3. Use Delegates for Calculating Calories and Notifications
We will use a delegate to calculate the total calories of a recipe and to notify the user if the total calories exceed 300.

Updated Code with Part 2 Requirements
Here’s the updated C# code:

csharp
Copy code
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    // Delegate for calorie notifications
    public delegate void CalorieNotificationHandler(string message);

    // Represents a single ingredient in a recipe
    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Constructor to initialize ingredient details
        public Ingredient(string name, double quantity, string unit, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        // Display method to show ingredient details
        public void Display()
        {
            Console.WriteLine($"{Quantity} {Unit} of {Name} ({Calories} calories, {FoodGroup})");
        }
    }

    // Represents a recipe with ingredients and steps
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        public event CalorieNotificationHandler CalorieNotification;

        // Constructor initializes empty lists
        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                ingredient.Display();
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }

            // Display total calories
            int totalCalories = CalculateTotalCalories();
            Console.WriteLine($"\nTotal Calories: {totalCalories}");

            // Notify if calories exceed 300
            if (totalCalories > 300)
            {
                CalorieNotification?.Invoke($"Warning: Total calories exceed 300 for recipe {Name}!");
            }
        }

        // Method to scale the recipe by a factor
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        // Method to reset quantities to original values
        public void ResetQuantities(double[] originalQuantities)
        {
            for (int i = 0; i < Ingredients.Count; i++)
            {
                Ingredients[i].Quantity = originalQuantities[i];
            }
        }

        // Method to clear all data for a new recipe
        public void ClearRecipe()
        {
            Ingredients.Clear();
            Steps.Clear();
        }

        // Method to calculate the total calories of a recipe
        public int CalculateTotalCalories()
        {
            int totalCalories = Ingredients.Sum(ingredient => ingredient.Calories);
            return totalCalories;
        }
    }

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
Key Enhancements and Features:
Generic Collection (List<Recipe>):

The recipes list is used to store an unlimited number of recipes.
Delegates:

A delegate (CalorieNotificationHandler) is used to handle calorie notifications when total calories exceed 300.
Additional Ingredient Information:

For each ingredient, the user can now enter calories and food group.
Display Recipes in Alphabetical Order:

The recipes are displayed in alphabetical order by name using LINQ’s OrderBy method.
User-Selected Recipe Display:

Users can choose which recipe to display by entering its name.
Calorie Calculation and Notification:

The application calculates the total calories for each recipe and notifies the user if the total exceeds 300 calories.
This updated application builds upon the initial implementation by adding these new features and enhancing usability, flexibility, and functionality.

https://github.com/VuyoYapi/Assignment-1-Part1
