using ConsoleTableExt;
using System.Diagnostics.CodeAnalysis;

namespace DrinksInfo
{
    public class TableVisualizationEngine
    {
        public static void ShowTable<T>(List<T> tableData, [AllowNull] string tableName) where T : class
        {
            Console.Clear();

            if (tableData == null)
                tableName = "";

            Console.WriteLine("\n\n");

            ConsoleTableBuilder.From(tableData).WithColumn(tableName).ExportAndWriteLine();
            Console.WriteLine("\n\n");
        }
    }
}
