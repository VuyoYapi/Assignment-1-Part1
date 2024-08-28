using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1_Part1
{
    
        public class Ingredient
        {
            // Name of the ingredient
            public string Name { get; set; }
            // Quantity of the ingredient
            public double Quantity { get; set; }
            // Unit of measurement for the ingredient
            public string Unit { get; set; }

            // Constructor to initialize ingredient details
            public Ingredient(string name, double quantity, string unit)
            {
                Name = name;
                Quantity = quantity;
                Unit = unit;
            }

            // Display method to show ingredient details
            public void Display()
            {
                Console.WriteLine($"{Quantity} {Unit} of {Name}");
            }
        }

        // Represents a recipe with ingredients and steps
        public class Recipe
        {
            // List of ingredients in the recipe
            public List<Ingredient> Ingredients { get; set; }
            // List of steps in the recipe
            public List<string> Steps { get; set; }

            // Constructor initializes empty lists
            public Recipe()
            {
                Ingredients = new List<Ingredient>();
                Steps = new List<string>();
            }

            // Method to display the recipe
            public void DisplayRecipe()
            {
                Console.WriteLine("\nIngredients:");
                foreach (var ingredient in Ingredients)
                {
                    ingredient.Display();
                }

                Console.WriteLine("\nSteps:");
                for (int i = 0; i < Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {Steps[i]}");
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
        }
    }

