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