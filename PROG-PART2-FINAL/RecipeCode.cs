using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_PART2_FINAL
{
    internal class RecipeCode
  public void Run()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;


        List<RecipeClass> recipes = new List<RecipeClass>();
        bool exit = false;

        while (!exit)
        {
            //option available to user
            Console.Clear();
            DisplayHeader("Recipe Application");
            Console.WriteLine("1. Add a new recipe");
            Console.WriteLine("2. View recipes");
            Console.WriteLine("3. Scale a recipe");
            Console.WriteLine("4. Delete a recipe");
            Console.WriteLine("5. Exit the application");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddRecipe(recipes);
                    break;
                case "2":
                    ViewRecipes(recipes);
                    break;
                case "3":
                    ScaleRecipe(recipes);
                    break;
                case "4":
                    DeleteRecipe(recipes);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        Console.ResetColor();
    }
    private void DisplayHeader(string title)
    {
        Console.Clear();
        Console.WriteLine(new string('=', 30));
        Console.WriteLine($"       {title}");
        Console.WriteLine(new string('=', 30));
    }
    //Adding recipe option no.1
    //User is asked to add reccipe
    private void AddRecipe(List<Recipe> recipes)
    {
        DisplayHeader("Add a New Recipe");

        Console.Write("Enter Recipe Name: ");
        string recipeName = Console.ReadLine();

        Recipe recipe = new Recipe { Name = recipeName };
        Console.Write("How many ingredients? ");
        int ingredientNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < ingredientNumber; i++)
        {
            Console.Write($"Enter Ingredient Name {i + 1}: ");
            string ingredientName = Console.ReadLine();

            Console.Write("Enter Calories: ");
            double calories = double.Parse(Console.ReadLine());

            Console.Write("Enter Food Group: ");
            string foodGroup = Console.ReadLine();

            Console.Write("Enter Measurement (e.g., 1 cup, 250 grams): ");
            string measurement = Console.ReadLine();

            recipe.Ingredients.Add(new Ingredient
            {
                Name = ingredientName,
                Calories = calories,
                FoodGroup = foodGroup,
                Measurement = measurement
            });

            Console.WriteLine();
        }
        Console.Write("How many steps? ");
        int howManySteps = int.Parse(Console.ReadLine());

        for (int i = 0; i < howManySteps; i++)
        {
            Console.Write($"Enter Step {i + 1}: ");
            recipe.Instructions.Add(Console.ReadLine());
        }

        recipes.Add(recipe);

        if (recipe.TotalCalories > 300)
        {
            Console.WriteLine("WARNING!: TOTAL CALORIES EXCEED 300.");
        }

        Console.WriteLine("Recipe added successfully!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private void ScaleRecipe(List<Recipe> recipes)
    {
        DisplayHeader("Scale a Recipe");

        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available to scale.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
        Console.WriteLine("Available Recipes:");
        for (int i = 0; i < sortedRecipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
        }

        Console.Write("Enter the number of the recipe you want to scale: ");
        int recipeIndex = int.Parse(Console.ReadLine()) - 1;

        if (recipeIndex < 0 || recipeIndex >= sortedRecipes.Count)
        {
            Console.WriteLine("Invalid recipe number.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Recipe selectedRecipe = sortedRecipes[recipeIndex];

        Console.Write("Enter scaling factor (e.g., 0.5, 2, 3): ");
        double scalingFactor = double.Parse(Console.ReadLine());

        Console.WriteLine($"RECIPE NAME: {selectedRecipe.Name}");
        Console.WriteLine("Scaled Ingredients:");
        foreach (var ingredient in selectedRecipe.Ingredients)
        {
            double scaledAmount = ScaleMeasurement(ingredient.Measurement, scalingFactor);
            Console.WriteLine($"- {ingredient.Name} ({ingredient.FoodGroup}), {ingredient.Calories} calories, {scaledAmount} (scaled by {scalingFactor})");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private void DeleteRecipe(List<Recipe> recipes)
    {
        DisplayHeader("Delete a Recipe");

        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available to delete.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
        Console.WriteLine("Available Recipes:");
        for (int i = 0; i < sortedRecipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
        }

        Console.Write("Enter the number of the recipe you want to delete: ");
        int recipeIndex = int.Parse(Console.ReadLine()) - 1;

        if (recipeIndex < 0 || recipeIndex >= sortedRecipes.Count)
        {
            Console.WriteLine("Invalid recipe number.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        recipes.RemoveAt(recipeIndex);
        Console.WriteLine("Recipe deleted successfully.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private double ScaleMeasurement(string measurement, double scalingFactor)
    {
        string numericPart = new string(measurement.TakeWhile(char.IsDigit).ToArray());
        if (double.TryParse(numericPart, out double amount))
        {
            return amount * scalingFactor;
        }
        return 0;
    }
    private void ViewRecipes(List<Recipe> recipes)
    {
        DisplayHeader("View Recipes");

        if (recipes.Count == 0)
        {
            Console.WriteLine("No recipes available.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        var sortedRecipes = recipes.OrderBy(r => r.Name).ToList();
        Console.WriteLine("Available Recipes:");
        for (int i = 0; i < sortedRecipes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
        }

        Console.Write("Enter the number of the recipe you want to view: ");
        int recipeIndex = int.Parse(Console.ReadLine()) - 1;

        if (recipeIndex < 0 || recipeIndex >= sortedRecipes.Count)
        {
            Console.WriteLine("Invalid recipe number.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }