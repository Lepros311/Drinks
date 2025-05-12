using Spectre.Console;

namespace Drinks
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
                    "-Close Application-", "Cocktail", "Ordinary Drink", "Punch/Party Drink", "Shake", "Other/Unknown", "Cocoa", "Shot", "Coffee/Tea", "Homemade Liqueur", "Beer", "Soft Drink"
                }));

            return menuChoice;
        }

        public static void ReturnToMainMenu()
        {
            Console.Write("\nPress any key to return to the Main Menu...");
            Console.ReadKey();
        }
    }
}

