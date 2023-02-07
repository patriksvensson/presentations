using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

public sealed class EmptySlideStep : SlideStep
{
    public override IRenderable Render(IRenderable? previous)
    {
        return new Text(string.Empty);
    }
}