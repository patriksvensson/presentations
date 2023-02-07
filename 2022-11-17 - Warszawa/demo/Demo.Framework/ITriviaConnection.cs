using System.Threading.Tasks;
using Spectre.Console;

namespace Demo.Framework;

public interface ITriviaConnection
{
    List<TriviaDifficulty> GetDifficulties();
    Task<List<TriviaCategory>> GetCategories();
    Task<TriviaQuestion> GetQuestion(StatusContext ctx, TriviaDifficulty difficulty, TriviaCategory category);
}
