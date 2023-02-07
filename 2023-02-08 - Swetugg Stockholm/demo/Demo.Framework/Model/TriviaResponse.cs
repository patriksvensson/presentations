namespace Demo.Framework;

public abstract class TriviaResponse
{
    [JsonProperty("response_code")]
    public int ResponseCode { get; set; }
}
