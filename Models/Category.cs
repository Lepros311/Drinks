using System.Text.Json.Serialization;

namespace Drinks.Models
{
    public class Category
    {
        public string strCategory { get; set; }
    }

    public class Categories
    {
        [JsonPropertyName("drinks")]

        public List<Category> CategoriesList { get; set; }
    }
}
