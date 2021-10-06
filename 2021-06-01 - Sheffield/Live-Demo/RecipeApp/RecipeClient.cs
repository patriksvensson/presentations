using Newtonsoft.Json;
using Spectre.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecipeApp
{
    public record Recipe(string Title, string Link, List<string> Ingredients, string thumbnail);

    public static class RecipeClient
    {
        private static HttpClient Client { get; } = new HttpClient();

        public record RecipeQueryResult(List<RecipeQueryItemResult> results);
        public record RecipeQueryItemResult(string title, string href, string ingredients, string thumbnail);

        public static string[] Ingredients = new string[]
        {
            "onions", "garlic", "butter", "water", "salt", "apples", "eggs",
            "cheese", "beets", "blueberries", "bananas", "brocolli", "kale",
            "kiwi", "pork", "lamb", "meat", "peas", "salmon", "rice", "carrots",
            "beef"
        };

        public static async Task<Stream> DownloadThumbnail(Recipe recipe)
        {
            return await Client.GetStreamAsync(recipe.thumbnail);
        }

        public static async Task<List<Recipe>> Query(IEnumerable<string> ingredients)
        {
            var query = string.Join(",", ingredients);
            var json = await Client.GetStringAsync($"http://www.recipepuppy.com/api/?i={query}");
            var result = JsonConvert.DeserializeObject<RecipeQueryResult>(json);
            return result.results.Select(r =>
            {
                return new Recipe(r.title.Trim(), r.href.Trim(), r.ingredients.Split(',').Select(x => x.Trim()).ToList(), r.thumbnail);
            }).ToList();
        }
    }
}
