using System.Text.Json;
using Drinks.Models;

namespace Drinks
{
    public class DrinksService
    {
        public async void GetCategories()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var serialize = JsonSerializer.Deserialize<Categories>(responseBody);

                    var returnedList = serialize.CategoriesList;

                    TableVisualizationEngine.ShowTable(returnedList, "Categories Menu");

                    //return responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    //return null;
                }
            }
        }
    }
}
