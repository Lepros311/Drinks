using DrinksInfo;
using DrinksInfo.Models;

class Program
{
    static async Task Main()
    {
        Console.Title = "Drinks";

        string? categoryChoice;

        do
        {
            DrinksService drinkService = new DrinksService();

            List<Category> categories = await drinkService.GetCategories();

            UI ui = new UI();

            categoryChoice = ui.CategorySelectionMenu(categories);

            switch (categoryChoice)
            {
                case "-Close Application-":
                    Console.WriteLine("\nGoodbye!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                default:
                    await drinkService.GetDrinksByCategory(categoryChoice);
                    UI.ReturnToMainMenu();
                    break;
            }

        } while (categoryChoice != "-Close Application-");
    }
}