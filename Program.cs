using DrinksInfo;

class Program
{
    static async Task Main()
    {

        Console.Title = "Drinks";

        string? menuChoice;

        do
        {
            DrinksService drinksService = new DrinksService();

            menuChoice = UI.MainMenu();

            switch (menuChoice)
            {
                case "-Close Application-":
                    Console.WriteLine("\nGoodbye!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                case "Cocktail":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Ordinary Drink":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Punch / Party Drink":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Shake":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Other / Unknown":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Cocoa":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Shot":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Coffee / Tea":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Homemade Liqueur":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Beer":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                case "Soft Drink":
                    await drinksService.GetDrinksByCategory(menuChoice);
                    UI.ReturnToMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        } while (menuChoice != "Close Application");
    }
}