using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class DemoSlide : Slide
{
    public override string Title { get; } = "Demo";

    protected override IRenderable GetRenderable()
    {
        return Align.Center(new FigletText("Demo").Color(Color.Green), VerticalAlignment.Middle);
    }
}
