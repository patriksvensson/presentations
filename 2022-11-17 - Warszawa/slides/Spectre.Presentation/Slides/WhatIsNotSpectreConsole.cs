using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class WhatIsNotSpectreConsole : BulletSlide
{
    public override string Title { get; } = "[red]What is it [u]not[/]?[/]";

    protected override IEnumerable<IRenderable> GetRenderables()
    {
        yield return new Markup("A TUI [i grey](Terminal UI)[/] library");

        yield return new Markup("No mouse support or clickable buttons");

        yield return new Markup("No automatic redrawing of widgets, or tracking of state");
    }
}
