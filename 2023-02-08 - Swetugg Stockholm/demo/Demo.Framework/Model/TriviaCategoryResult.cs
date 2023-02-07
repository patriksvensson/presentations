namespace Demo.Framework;

public sealed class TriviaCategoryResult
{
    [JsonProperty("trivia_categories")]
    public List<TriviaCategory> Categories { get; set; }

    public TriviaCategoryResult()
    {
        Categories = new List<TriviaCategory>();
    }
}
