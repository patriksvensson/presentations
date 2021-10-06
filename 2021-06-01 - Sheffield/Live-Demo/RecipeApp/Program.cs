using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            while (true)
            {
                try
                {
                    AnsiConsole.Clear();
                    AnsiConsole.Render(new FigletText("Recipe finder"));

                    var ingredients = AnsiConsole.Prompt(new MultiSelectionPrompt<string>()
                        .Title("Select ingredients")
                        .Required()
                        .AddChoices(RecipeClient.Ingredients));

                    var recipes = await RecipeClient.Query(ingredients);
                    if (recipes.Count == 0)
                    {
                        AnsiConsole.Write("No recipe found!");
                    }

                    var recipe = AnsiConsole.Prompt(new SelectionPrompt<Recipe>()
                        .Title("Select recipe")
                        .UseConverter(recipe => recipe.Title)
                        .AddChoices(recipes));

                    var tree = new Tree("Ingredients");
                    foreach (var item in recipe.Ingredients)
                    {
                        tree.AddNode(item);
                    }

                    AnsiConsole.MarkupLine($"[yellow]{recipe.Title}[/]");
                    AnsiConsole.Render(new Grid().AddColumns(2)
                        .AddRow("[grey37]Link[/]", $"[link={recipe.Link} u]{recipe.Link}[/]"));

                    // Got an image?
                    if (!string.IsNullOrWhiteSpace(recipe.thumbnail))
                    {
                        var stream = await RecipeClient.DownloadThumbnail(recipe);

                        AnsiConsole.WriteLine();
                        AnsiConsole.Render(new CanvasImage(stream)
                        {
                            MaxWidth = 25,
                            PixelWidth = 2,
                        });
                    }


                    AnsiConsole.WriteLine();
                    AnsiConsole.Render(tree);
                }
                catch(Exception ex)
                {
                    AnsiConsole.Clear();
                    AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything);
                }

                AnsiConsole.WriteLine();
                if (!AnsiConsole.Confirm("Search again?"))
                {
                    break;
                }
            }
        }
    }
}
