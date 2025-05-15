using Spectre.Console;
using DrinksInfo.Models;

namespace DrinksInfo
{
    internal class UI
    {
        public string CategorySelectionMenu(List<Category> categories)
        {
            Console.Clear();

            List<Category> modifiedCategories = new List<Category>
            {
                new Category { StrCategory = "-Close Application-" }
            };
            modifiedCategories.AddRange(categories);
  
            var selectedCategory = AnsiConsole.Prompt(
                new SelectionPrompt<Category>()
                .Title("[bold]SELECT A CATEGORY:[/]")
                .PageSize(15)
                .AddChoices(modifiedCategories)
                .UseConverter(c => $"{c.StrCategory}"));

            return selectedCategory.StrCategory;
        }

        public async Task DrinkSelectionMenu(List<Drink> drinks)
        {
            if (drinks == null || drinks.Count == 0)
            {
                AnsiConsole.Markup("[red]No drinks available.[/]");
                return;
            }

            var selectedDrink = AnsiConsole.Prompt(
                new SelectionPrompt<Drink>()
                .Title("[bold]SELECT A DRINK:[/]")
                .PageSize(15)
                .AddChoices(drinks)
                .UseConverter(d => $"{d.IdDrink}\t\t{d.StrDrink}"));

            DrinksService drinksService = new DrinksService();

            await drinksService.GetDrink(selectedDrink.IdDrink);
        }

        public static void ReturnToMainMenu()
        {
            Console.Write("\nPress any key to return to the CATEGORY menu...");
            Console.ReadKey();
        }
    }
}

