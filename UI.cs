using Spectre.Console;
using DrinksInfo.Models;

namespace DrinksInfo
{
    internal class UI
    {
        public static string MainMenu()
        {
            Console.Clear();

            var menuChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("SELECT A CATEGORY")
                .PageSize(15)
                .AddChoices(new[]
                {
                    "-Close Application-", "Cocktail", "Ordinary Drink", "Punch / Party Drink", "Shake", "Other / Unknown", "Cocoa", "Shot", "Coffee / Tea", "Homemade Liqueur", "Beer", "Soft Drink"
                }));

            return menuChoice;
        }

        //public void GetDrinksInput(string category)
        //{
        //    DrinksService drinksService = new DrinksService();

        //    drinksService.GetDrinksByCategory(category);
        //}

        public static void DrinkSelectionMenu(List<Drink> drinks)
        {
            if (drinks == null || drinks.Count == 0)
            {
                AnsiConsole.Markup("[red]No drinks available.[/]");
                return;
            }

            var selectedDrink = AnsiConsole.Prompt(
                new SelectionPrompt<Drink>()
                .Title("[bold]Select a drink:[/]")
                .PageSize(15)
                .AddChoices(drinks)
                .UseConverter(d => $"{d.idDrink}\t\t{d.strDrink}"));

            AnsiConsole.Markup($"[green]You selected: {selectedDrink.strDrink}[/]");
        }

        public static void ReturnToMainMenu()
        {
            Console.Write("\nPress any key to return to the Main Menu...");
            Console.ReadKey();
        }
    }
}

