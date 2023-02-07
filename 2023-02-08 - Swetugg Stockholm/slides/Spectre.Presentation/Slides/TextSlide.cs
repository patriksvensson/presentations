using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class TextSlide : SlideWithSteps
{
    public override string Title { get; } = "[grey37]Features:[/] Text";

    protected override IEnumerable<SlideStep> GetSteps()
    {
        yield return new Slide1();
        yield return new Slide2();
        yield return new Slide3();
        yield return new Slide4();
        yield return new Slide5();
    }

    public sealed class Slide1 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Bullet(new Markup(
                "[bold]bold[/], [dim]dim[/], [italic]italic[/], [underline]underline[/], " +
                "[strikethrough]strikethrough[/], [reverse]reverse[/], [blink]blink[/], " +
                "[link=https://spectreconsole.net]link[/]"));
        }
    }

    public sealed class Slide2 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Rows(
                previous!,
                new Text(string.Empty),
                new Bullet(new Markup(
                    "[yellow][[b]][/]bold[yellow][[/]][/], " +
                    "[yellow][[dim]][/]dim[yellow][[/]][/], " +
                    "[yellow][[i]][/]italic[yellow][[/]][/],\n" +
                    "[yellow][[u]][/]underline[yellow][[/]][/], " +
                    "[yellow][[strike]][/]strikethrough[yellow][[/]][/],\n" +
                    "[yellow][[reverse]][/]reverse[yellow][[/]][/], " +
                    "[yellow][[blink]][/]blink[yellow][[/]][/]\n" +
                    "[yellow][[link[grey37]=[/]https://spectreconsole.net]][/]link[yellow][[/]][/]")));
        }
    }

    public sealed class Slide3 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Bullet(new Markup(
                "[red]red[/], [green]green[/], [blue]blue[/], [rgb(100,149,237)]Cornflower blue[/],\n" +
                "[#DC143C]Crimson red[/], [black on red]black on red[/]"));
        }
    }

    public sealed class Slide4 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Rows(
                previous!,
                new Text(string.Empty),
                new Bullet(new Markup(
                    "[red][[red]][/]red[red][[/]][/], [green][[green]][/]green[green][[/]][/], [blue][[blue]][/]blue[blue][[/]][/],\n" +
                    "[rgb(100,149,237)][[rgb(100,149,237)]][/]Cornflower blue[rgb(100,149,237)][[/]][/],\n" +
                    "[#DC143C][[#DC143C]][/]Crimson red[#DC143C][[/]][/],\n" +
                    "[black on red][[black on red]][/]black on red[black on red][[/]][/]")));
        }
    }

    public sealed class Slide5 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var table = new Table().HideHeaders().NoBorder();
            table.AddColumn("Feature");
            table.AddRow(
                new Markup("Word wrap text and justify it to the\n[green]left[/], [yellow]center[/] or [blue]right[/]."));
            table.AddRow(new Text(string.Empty));

            var loremTable = new Grid();
            var lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            loremTable.AddColumn(new GridColumn().LeftAligned());
            loremTable.AddColumn(new GridColumn().Centered());
            loremTable.AddColumn(new GridColumn().RightAligned());
            loremTable.AddRow($"[green]{lorem}[/]", $"[yellow]{lorem}[/]", $"[blue]{lorem}[/]");

            table.AddEmptyRow();
            table.AddRow(loremTable);

            return table;
        }
    }
}
