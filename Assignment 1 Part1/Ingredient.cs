using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Part1
{
    public delegate void CalorieNotificationHandler(string message);
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
    }

