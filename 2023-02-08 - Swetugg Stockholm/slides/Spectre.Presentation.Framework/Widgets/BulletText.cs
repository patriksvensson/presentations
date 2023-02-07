using System;
using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

public sealed class Bullet : Renderable
{
    private readonly IRenderable _renderable;

    public Bullet(IRenderable renderable)
    {
        _renderable = renderable ?? throw new ArgumentNullException(nameof(renderable));
    }

    public Bullet(string markup)
    {
        _renderable = new Markup(markup);
    }

    protected override IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
    {
        var grid = new Grid().AddColumns(2);
        grid.AddRow(new Markup("[yellow]◼[/]"), _renderable);

        return ((IRenderable)grid).Render(options, maxWidth);
    }
}
