using Drinks;

Console.Title = "Drinks";

string? menuChoice;

do
{
    menuChoice = UI.MainMenu();

    switch (menuChoice)
    {
        case "-Close Application-":
            Console.WriteLine("\nGoodbye!");
            Thread.Sleep(2000);
            Environment.Exit(0);
            break;
        case "Cocktail":
            //Display.PrintAllRecords("Ordinary Drink");
            UI.ReturnToMainMenu();
            break;
        case "Punch/Party Drink":
            //RecordsController.AddRecord();
            UI.ReturnToMainMenu();
            break;
        case "Shake":
            //RecordsController.EditRecord();
            UI.ReturnToMainMenu();
            break;
        case "Other/Unknown":
            //RecordsController.DeleteRecord();
            UI.ReturnToMainMenu();
            break;
        case "Cocoa":
            break;
        case "Shot":
            break;
        case "Coffee/Tea":
            break;
        case "Homemade Liqueur":
            break;
        case "Beer":
            break;
        case "Soft Drink":
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }
} while (menuChoice != "Close Application");
