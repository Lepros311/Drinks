using System.Reflection;
using System.Text.Json;
using System.Web;
using DrinksInfo.Models;
using Drinks.Models;

namespace DrinksInfo
{
    public class DrinksService
    {
        //public async void GetCategories()
        //{
        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            HttpResponseMessage response = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/");

        //            response.EnsureSuccessStatusCode();

        //            string responseBody = await response.Content.ReadAsStringAsync();

        //            var serialize = JsonSerializer.Deserialize<Categories>(responseBody);

        //            var returnedList = serialize.CategoriesList;

        //            TableVisualizationEngine.ShowTable(returnedList, "Categories Menu");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine($"Request error: {e.Message}");
        //        }
        //    }
        //}

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

                    UI.DrinkSelectionMenu(serialize.DrinksList);

                    //var returnedList = serialize.DrinksList;

                    //TableVisualizationEngine.ShowTable(returnedList, "Drinks Menu");
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
                    HttpResponseMessage response = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?c={HttpUtility.UrlEncode(drink)}");

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    var serialize = JsonSerializer.Deserialize<DrinkDetailObject>(responseBody);

                    var returnedList = serialize.DrinkDetailList;

                    var drinkDetail = returnedList[0];

                    List<object> prepList = new();

                    string formattedName = "";

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


                    //var returnedList = serialize.DrinksList;

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
