using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class WhatIsSpectreConsole : BulletSlide
{
    public override string Title { get; } = "What is Spectre.Console?";

    protected override IEnumerable<IRenderable> GetRenderables()
    {
        yield return new Markup(
            "A .NET library that makes it [u blue]easy[/]\nto create " +
            "[red]b[/][blue]e[/][green]a[/][yellow]u[/][orange1]t[/][red]i[/][green]f[/][blue]u[/][yellow]l[/] " +
            "console applications");

        yield return new Markup("Targets [yellow]net7.0[/], [yellow]net6.0[/] and [yellow]netstandard2.0[/]");

        yield return new Markup("Inspired by [blue]Rich[/] for [green]Python[/] 🐍");
    }
}
