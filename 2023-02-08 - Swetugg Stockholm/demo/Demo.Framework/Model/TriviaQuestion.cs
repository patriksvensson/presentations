using System.Linq;
using System.Net;

namespace Demo.Framework;

public sealed class TriviaQuestion
{
    [JsonProperty("category")]
    public string Category { get; set; } = null!;

    [JsonProperty("difficulty")]
    public string Difficulty { get; set; } = null!;

    [JsonProperty("question")]
    public string Question { get; set; } = null!;

    [JsonProperty("correct_answer")]
    public string Answer { get; set; } = null!;

    [JsonProperty("incorrect_answers")]
    public List<string> Choices { get; set; } = null!;

    public TriviaQuestion()
    {
        Choices = new List<string>();
    }

    public TriviaQuestion Normalize()
    {
        var question = new TriviaQuestion
        {
            Category = Category,
            Difficulty = Difficulty,
            Question = WebUtility.HtmlDecode(Question),
            Answer = WebUtility.HtmlDecode(Answer),
        };

        question.Choices.AddRange(Choices);
        question.Choices.Add(Answer);
        question.Choices.Shuffle();
        question.Choices = question.Choices.Select(x => WebUtility.HtmlDecode(x)).ToList();

        return question;
    }
}