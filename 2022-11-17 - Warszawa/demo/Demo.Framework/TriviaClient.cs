using System.Threading.Tasks;
using Spectre.Console;

namespace Demo.Framework;

public sealed class TriviaClient
{
    private readonly ITriviaConnection _connection;

    public TriviaClient()
    {
        _connection = new TriviaConnection();
    }

    public TriviaClient(ITriviaConnection connection)
    {
        _connection = connection ?? throw new System.ArgumentNullException(nameof(connection));
    }

    public List<TriviaDifficulty> GetDifficulties()
    {
        return _connection.GetDifficulties();
    }

    public async Task<List<TriviaCategory>> GetCategories()
    {
        return await _connection.GetCategories();
    }

    public async Task<TriviaQuestion> GetQuestion(StatusContext ctx, TriviaDifficulty difficulty, TriviaCategory category)
    {
        return await _connection.GetQuestion(ctx, difficulty, category);
    }
}
