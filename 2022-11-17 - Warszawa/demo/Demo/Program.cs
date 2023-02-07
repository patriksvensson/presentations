namespace Demo;

public static class Program
{
    public static async Task Main(string[] args)
    {
        // Create the client
        var client = new TriviaClient(new OfflineTriviaConnection());

        AnsiConsole.Clear();
        AnsiConsole.Write(new FigletText("Trivia"));

        // Get categories
        var categories = await AnsiConsole.Status()
            .StartAsync("Getting categories...", async ctx =>
            {
                return await client.GetCategories();
            });

        // Select category
        var category = AnsiConsole.Prompt(
            new SelectionPrompt<TriviaCategory>()
                .Title("Select a [green]Trivia category[/]")
                .AddChoices(categories)
                .WrapAround()
                .UseConverter(t => t.Name));

        // Select difficulty
        var difficulties = client.GetDifficulties();
        var difficulty = AnsiConsole.Prompt(
            new SelectionPrompt<TriviaDifficulty>()
                .Title("How difficult?")
                .AddChoices(difficulties));

        var count = 1;
        while (true)
        {
            AnsiConsole.Write(new Rule($"Question #{count}"));

            // Get the question
            var question = await AnsiConsole.Status()
                .StartAsync("Getting question...", async ctx =>
                {
                    return await client.GetQuestion(ctx, difficulty, category);
                });

            var answer = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(question.Question)
                    .AddChoices(question.Choices)
                    .UseConverter(q =>
                    {
                        var index = question.Choices.IndexOf(q);
                        return $"{index + 1}) {q.EscapeMarkup()}";
                    })
                    .WrapAround());

            if (answer == question.Answer)
            {
                AnsiConsole.Write(
                    new Panel("[green]Correct[/] 👍")
                        .BorderColor(Color.Green));
            }
            else
            {
                AnsiConsole.Write(
                    new Panel($"[red]Incorrect[/] 👎\nCorrect answer was: [u]{question.Answer.EscapeMarkup()}[/]")
                        .BorderColor(Color.Red));
            }

            count++;
        }
    }
}