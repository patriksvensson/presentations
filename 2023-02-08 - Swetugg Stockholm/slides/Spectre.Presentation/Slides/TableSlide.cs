using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class TableSlide : BulletSlide
{
    public override string Title { get; } = "[grey37]Features:[/] Tables";

    protected override IEnumerable<IRenderable> GetRenderables()
    {
        yield return new Markup("Used to represent tabular data\n");

        yield return new Markup("Implements [blue]IRenderable[/]\n");

        yield return new Markup("Supports nesting of [blue]IRenderable[/]");
    }
}
