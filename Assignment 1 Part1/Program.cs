using Assignment_1_Part1;
using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();  // Create a new Recipe object
            double[] originalQuantities = null;  // To store original quantities for reset

            while (true)
            {
                Console.WriteLine("\nRecipe Application");
                Console.WriteLine("1. Enter a new recipe");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipe.ClearRecipe();
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
                            recipe.Ingredients.Add(new Ingredient(name, quantity, unit));
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
                        break;

                    case "2":
                        recipe.DisplayRecipe();
                        break;

                    case "3":
                        Console.WriteLine("Enter scale factor (0.5 for half, 2 for double, 3 for triple): ");
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;

                    case "4":
                        recipe.ResetQuantities(originalQuantities);
                        break;

                    case "5":
                        recipe.ClearRecipe();
                        Console.WriteLine("Recipe cleared.");
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}