using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class TreeSlide : BulletSlide
{
    public override string Title { get; } = "[grey37]Features:[/] Trees";

    protected override IEnumerable<IRenderable> GetRenderables()
    {
        yield return new Markup("Used to represent hierarchical data\n");

        yield return new Markup("Also supports nesting of [blue]IRenderable[/]:s");
    }
}
