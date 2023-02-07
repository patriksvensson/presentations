namespace Demo.Framework;

public sealed class TriviaCategory
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = null!;
}
