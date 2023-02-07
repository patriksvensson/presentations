using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class ChartsSlide : SlideWithSteps
{
    public override string Title { get; } = "[grey37]Features:[/] Charts";

    protected override IEnumerable<SlideStep> GetSteps()
    {
        yield return new Slide1();
        yield return new Slide2();
    }

    public sealed class Slide1 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Rows(
                new Markup("[grey]1)[/] Bar charts\n"),
                new BarChart()
                    .LeftAlignLabel()
                    .Label("Relation between [red]Foo[/]:s, [green]Bar[/]:s and [yellow]Corgi[/]:s")
                    .AddItem("Foo", 32, Color.Red)
                    .AddItem("Bar", 64, Color.Green)
                    .AddItem("Corgi", 100, Color.Yellow));
        }
    }

    public sealed class Slide2 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Rows(
                new Markup("[grey]2)[/] Breakdown charts\n"),
                new BreakdownChart()
                .AddItem("C#", 64, Color.Green)
                .AddItem("Rust", 32, Color.Red)
                .AddItem("VB.NET", 1, Color.Blue)
                .AddItem("Scala", 1, Color.Magenta1)
                .AddItem("Elixir", 8, Color.Khaki1)
                .AddItem("Mew", 1, Color.LightPink3)
                .AddItem("PowerShell", 16, Color.Yellow));
        }
    }
}
