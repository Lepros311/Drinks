using ConsoleTableExt;
using Spectre.Console;
using System.Diagnostics.CodeAnalysis;

namespace DrinksInfo
{
    public class TableVisualizationEngine
    {
        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
        {
            Console.Clear();
            if (tableData == null || tableData.Count == 0)
            {
                Console.WriteLine("No data available.");
                return;
            }

            var table = new Table();

            if (!string.IsNullOrEmpty(tableName))
            {
                var rule = new Rule($"[green1]{tableName}[/]");
                rule.Justification = Justify.Left;
                AnsiConsole.Write(rule);
            }

            table.AddColumn("Property");
            table.AddColumn("Value");
            table.HideHeaders();

            foreach (var item in tableData)
            {
                var keyProperty = item.GetType().GetProperty("Key");
                var valueProperty = item.GetType().GetProperty("Value");
                if (keyProperty != null && valueProperty != null)
                {
                    var key = keyProperty.GetValue(item)?.ToString() ?? string.Empty;
                    var value = valueProperty.GetValue(item)?.ToString() ?? string.Empty;
                    table.AddRow($"[cyan1]{key}[/]", value);
                }
            }

            AnsiConsole.Write(table);
        }

    }
}
