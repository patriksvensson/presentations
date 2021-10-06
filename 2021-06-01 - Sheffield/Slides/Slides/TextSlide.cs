using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public class TextSlide : Slide
    {
        public override string Title => "[grey37]Features:[/] Text";

        public TextSlide()
            : base(
                  new EmptyStep(),
                  new FirstStep(),
                  new SecondStep(),
                  new ThirdStep(),
                  new FourthStep(),
                  new FifthStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return GetBullet(
                    "[bold]bold[/], [dim]dim[/], [italic]italic[/], [underline]underline[/], "
                        + "[strikethrough]strikethrough[/], [reverse]reverse[/], [blink]blink[/], " 
                        + "[link=https://spectreconsole.net]link[/]");
            }
        }

        public sealed class SecondStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, 
                    Text.NewLine,
                    GetBullet(
                        "[yellow][[b]][/]bold[yellow][[/]][/], " +
                        "[yellow][[dim]][/]dim[yellow][[/]][/], " +
                        "[yellow][[i]][/]italic[yellow][[/]][/],\n" +
                        "[yellow][[u]][/]underline[yellow][[/]][/], " +
                        "[yellow][[strike]][/]strikethrough[yellow][[/]][/],\n" +
                        "[yellow][[reverse]][/]reverse[yellow][[/]][/], " +
                        "[yellow][[blink]][/]blink[yellow][[/]][/]\n" +
                        "[yellow][[link[grey37]=[/]https://spectreconsole.net]][/]link[yellow][[/]][/]"));
            }
        }

        public sealed class ThirdStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return GetBullet(
                    "[red]red[/], [green]green[/], [blue]blue[/], [rgb(100,149,237)]Cornflower blue[/],\n" +
                    "[#DC143C]Crimson red[/], [black on red]black on red[/]");
            }
        }

        public sealed class FourthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous,
                    Text.NewLine,
                    GetBullet(
                        "[red][[red]][/]red[red][[/]][/], [green][[green]][/]green[green][[/]][/], [blue][[blue]][/]blue[blue][[/]][/],\n" +
                        "[rgb(100,149,237)][[rgb(100,149,237)]][/]Cornflower blue[rgb(100,149,237)][[/]][/],\n" +
                        "[#DC143C][[#DC143C]][/]Crimson red[#DC143C][[/]][/],\n" +
                        "[black on red][[black on red]][/]black on red[black on red][[/]][/]"));
            }
        }

        public sealed class FifthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var table = new Table().HideHeaders().NoBorder();
                table.AddColumn("Feature");
                table.AddRow(
                    new Markup("Word wrap text and justify it to the\n[green]left[/], [yellow]center[/] or [blue]right[/]."));

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
}
