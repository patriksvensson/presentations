using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class ColorsSlide : SlideWithSteps
{
    public override string Title { get; } = "[grey37]Features:[/] Colors";

    protected override IEnumerable<SlideStep> GetSteps()
    {
        yield return new Slide1();
        yield return new Slide2();
        yield return new Slide3();
    }

    public sealed class Slide1 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var colorTable = new Table().Collapse().HideHeaders().NoBorder();
            colorTable.AddColumn("Desc", c => c.PadRight(3)).AddColumn("Colors", c => c.PadRight(0));
            colorTable.AddRow(
                new Markup(
                    "✓ [bold grey37]NO_COLOR support[/]"),
                new Text(" "));

            return colorTable;
        }
    }

    public sealed class Slide2 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var colorTable = new Table().Collapse().HideHeaders().NoBorder();
            colorTable.AddColumn("Desc", c => c.PadRight(3)).AddColumn("Colors", c => c.PadRight(0));
            colorTable.AddRow(
                new Markup(
                    "✓ [bold grey37]NO_COLOR support[/]\n" +
                    "✓ [bold green]3-bit color[/]\n" +
                    "✓ [bold blue]4-bit color[/]\n" +
                    "✓ [bold purple]8-bit color[/]\n" +
                    "✓ [bold yellow]24-bit color[/]\n"),
                new ColorBox(ColorSystem.TrueColor));

            return colorTable;
        }
    }

    public sealed class Slide3 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var colorTable = new Table().Collapse().HideHeaders().NoBorder();
            colorTable.AddColumn("Desc", c => c.PadRight(3)).AddColumn("Colors", c => c.PadRight(0));
            colorTable.AddRow(
                new Markup(
                    "✓ [bold grey37]NO_COLOR support[/]\n" +
                    "✓ [bold green]3-bit color[/]\n" +
                    "✓ [bold blue]4-bit color[/]\n" +
                    "✓ [bold purple]8-bit color[/]\n" +
                    "✓ [bold yellow]24-bit color[/]\n" +
                    "✓ [bold green blink]Auto conversion[/]\n"),
                new ColorBox(ColorSystem.TrueColor));

            return colorTable;
        }
    }
}
