namespace Demo.Framework;

public sealed class TriviaQuestionResult : TriviaResponse
{
    [JsonProperty("results")]
    public List<TriviaQuestion> Results { get; set; }

    public TriviaQuestionResult()
    {
        Results = new List<TriviaQuestion>();
    }
}
