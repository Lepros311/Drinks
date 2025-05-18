using System.Reflection;
using System.Text.Json;
using System.Web;
using DrinksInfo.Models;
using Drinks.Models;

namespace DrinksInfo
{
    public class DrinksService
    {
        public async Task<List<Category>> GetCategories()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/list.php?c=list");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var serialize = JsonSerializer.Deserialize<Categories>(responseBody);

                    return serialize?.CategoriesList ?? new List<Category>();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                    return new List<Category>();
                }
            }
        }

        public async Task GetDrinksByCategory(string category)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={HttpUtility.UrlEncode(category)}");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var serialize = JsonSerializer.Deserialize<DrinksListing>(responseBody);

                    if (serialize?.DrinksList == null || serialize.DrinksList.Count == 0)
                    {
                        Console.WriteLine("No drinks found for this category.");
                        return;
                    }

                    UI ui = new UI();

                    await ui.DrinkSelectionMenu(serialize.DrinksList);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }

        public async Task GetDrink(string drink)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={HttpUtility.UrlEncode(drink)}");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var serialize = JsonSerializer.Deserialize<DrinkDetailObject>(responseBody);

                    var returnedList = serialize.DrinkDetailList;

                    var drinkDetail = returnedList[0];

                    List<object> prepList = new();

                    string formattedName = string.Empty;

                    foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                    {
                        if (prop.Name.Contains("str"))
                        {
                            formattedName = prop.Name.Substring(3);
                        }

                        if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                        {
                            prepList.Add(new
                            {
                                Key = formattedName,
                                Value = prop.GetValue(drinkDetail)
                            });
                        }
                    }

                    TableVisualizationEngine.ShowTable(prepList, drinkDetail.strDrink);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
        }
    }
}
