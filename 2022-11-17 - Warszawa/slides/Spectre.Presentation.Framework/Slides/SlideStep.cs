using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

public abstract class SlideStep
{
    public abstract IRenderable Render(IRenderable? previous);
}
