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
![Second part of the project](https://github.com/user-attachments/assets/3b01c6c4-a930-495e-97ec-3b5e0ae8a965)

https://github.com/VuyoYapi/Assignment-1-Part1
