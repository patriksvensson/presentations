using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class ThanksSlide : AnimatedSlide
{
    public override string Title { get; } = "Thanks";
    public override bool ShowHeader => false;

    protected override IRenderable GetRenderable()
    {
        var layout = new Layout()
            .SplitRows(
                new Layout("Top"),
                new Layout("Bottom"));

        layout["Top"].Update(
            Align.Center(
                new FigletText("Thanks")
                .Color(Color.Yellow), VerticalAlignment.Bottom));

        layout["Bottom"].Update(
            Align.Center(
                new Table()
                    .AddColumn(new TableColumn(string.Empty).RightAligned().PadRight(2))
                    .AddColumn(new TableColumn(string.Empty).LeftAligned())
                    .Collapse().NoBorder()
                    .Title("[blue]Patrik Svensson[/] 👋\npatrik@patriksvensson.se")
                    .AddRow("[grey]Twitter:[/]", "[link=https://twitter.com/patriksvensson][grey]@[/]firstdrafthell[/]")
                    .AddRow("[grey]Mastodon:[/]", "[link=https://mstdn.social/@patriksvensson][grey]@[/]patriksvensson[grey]@mstdn.social[/][/]"),
                VerticalAlignment.Middle));

        return layout;
    }
}