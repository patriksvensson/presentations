namespace Demo.Framework;

public sealed class TriviaTokenResponse : TriviaResponse
{
    [JsonProperty("message")]
    public string Message { get; set; } = null!;

    [JsonProperty("token")]
    public string Token { get; set; } = null!;
}
