using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public class ColorsSlide : Slide
    {
        public override string Title => "[grey37]Features:[/] Colors";

        public ColorsSlide()
            : base(
                  new EmptyStep(),
                  new FirstStep(),
                  new SecondStep(),
                  new ThirdStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        public sealed class SecondStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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
                    new ColorBox(height: 8, ColorSystem.TrueColor));

                return colorTable;
            }
        }

        public sealed class ThirdStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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
                    new ColorBox(height: 8, ColorSystem.TrueColor));

                return colorTable;
            }
        }
    }
}
