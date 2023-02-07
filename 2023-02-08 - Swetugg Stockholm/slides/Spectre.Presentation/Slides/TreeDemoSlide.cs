using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class TreeDemoSlide : SlideWithSteps
{
    public override string Title { get; } = "[grey37]Features:[/] Trees (demo)";
    public override bool ShowHeader => true;

    protected override IEnumerable<SlideStep> GetSteps()
    {
        yield return new Slide1();
        yield return new Slide2();
        yield return new Slide3();
        yield return new Slide4();
        yield return new Slide5();
        yield return new Slide6();
        yield return new Slide7(TreeGuide.Ascii);
        yield return new Slide7(TreeGuide.BoldLine);
        yield return new Slide7(TreeGuide.DoubleLine);
        yield return new Slide8();
    }

    public sealed class Slide1 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("Root");
            var item1 = tree.AddNode("Item 1");
            {
                var item1_1 = item1.AddNode("Item 1-1");
                {
                    item1_1.AddNode("Item 1-1-1");
                }

                var item1_2 = item1.AddNode("Item 1-2");
                {
                    item1_2.AddNode("Item 1-2-1");
                    item1_2.AddNode("Item 1-2-2");
                }
            }

            var item2 = tree.AddNode("Item 2");
            {
                var item2_1 = item2.AddNode("Item 2-1");
                {
                    item2_1.AddNode("Item 2-1-1");
                    item2_1.AddNode("Item 2-1-2");
                }
            }

            return tree;
        }
    }

    public sealed class Slide2 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("[yellow]Root[/]");
            var item1 = tree.AddNode("[green]Item 1[/]");
            {
                var item1_1 = item1.AddNode("[green]Item 1-1[/]");
                {
                    item1_1.AddNode("Item [green]1[/]-[red]1[/]-[blue]1[/]");
                }

                var item1_2 = item1.AddNode("[red]Item 1-2[/]");
                {
                    item1_2.AddNode("Item [green]1[/]-[red]2[/]-[blue]1[/]");
                    item1_2.AddNode("Item [green]1[/]-[red]2[/]-[blue]2[/]");
                }
            }

            var item2 = tree.AddNode("[green]Item 2[/]");
            {
                var item2_1 = item2.AddNode("[red]Item 2-1[/]");
                {
                    item2_1.AddNode("Item [green]2[/]-[red]1[/]-[blue]1[/]");
                    item2_1.AddNode("Item [green]2[/]-[red]1[/]-[blue]2[/]");
                }
            }

            return tree;
        }
    }

    public sealed class Slide3 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("[yellow]Root[/]");
            var item1 = tree.AddNode("[green]Item 1[/]");
            {
                var item1_1 = item1.AddNode("[green]Item 1-1[/]").Collapse();
                {
                    item1_1.AddNode("Item [green]1[/]-[red]1[/]-[blue]1[/]");
                }

                var item1_2 = item1.AddNode("[red]Item 1-2[/]").Collapse();
                {
                    item1_2.AddNode("Item [green]1[/]-[red]2[/]-[blue]1[/]");
                    item1_2.AddNode("Item [green]1[/]-[red]2[/]-[blue]2[/]");
                }
            }

            var item2 = tree.AddNode("[green]Item 2[/]");
            {
                var item2_1 = item2.AddNode("[red]Item 2-1[/]");
                {
                    item2_1.AddNode("Item [green]2[/]-[red]1[/]-[blue]1[/]");
                    item2_1.AddNode("Item [green]2[/]-[red]1[/]-[blue]2[/]");
                }
            }

            return tree;
        }
    }

    public sealed class Slide4 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("[yellow]Root[/]");
            var item1 = tree.AddNode("[green]Item 1[/]");
            {
                var item1_1 = item1.AddNode("[green]Item 1-1[/]").Collapse();
                {
                    item1_1.AddNode("Item [green]1[/]-[red]1[/]-[blue]1[/]");
                }
                var item1_2 = item1.AddNode("[red]Item 1-2[/]").Collapse();
                {
                    item1_2.AddNode("Item [green]1[/]-[red]2[/]-[blue]1[/]");
                    item1_2.AddNode("Item [green]1[/]-[red]2[/]-[blue]2[/]");
                }
            }

            var item2 = tree.AddNode("[green]Item 2[/]").Collapse();
            {
                var item2_1 = item2.AddNode("[red]Item 2-1[/]");
                {
                    item2_1.AddNode("Item [green]2[/]-[red]1[/]-[blue]1[/]");
                    item2_1.AddNode("Item [green]2[/]-[red]1[/]-[blue]2[/]");
                }
            }

            return tree;
        }
    }

    public sealed class Slide5 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("[yellow]Root[/]");
            var item1 = tree.AddNode("[green]Item 1[/]");
            {
                item1.AddNode("[green]Item 1-1[/]").Collapse();
                item1.AddNode("[red]Item 1-2[/]").Collapse();
            }
            tree.AddNode("[green]Item 2[/]");
            tree.AddNode(new Table()
                .AddColumns("Foo", "Bar", "Baz")
                .AddRow("Qux", "Corgi", "Waldo"));

            return tree;
        }
    }

    public sealed class Slide6 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("[yellow]Root[/]");
            var item1 = tree.AddNode("[green]Item 1[/]");
            {
                item1.AddNode("[green]Item 1-1[/]").Collapse();
                item1.AddNode("[red]Item 1-2[/]").Collapse();
            }
            tree.AddNode("[green]Item 2[/]");

            var tableNode = tree.AddNode(new Table()
                .AddColumns("Foo", "Bar", "Baz")
                .AddRow("Qux", "Corgi", "Waldo"));

            tableNode.AddNode(
                new BreakdownChart()
                    .ShowPercentage()
                    .Compact()
                    .Width(40)
                    .AddItem("C#", 78, Color.Yellow)
                    .AddItem("F#", 8, Color.Blue)
                    .AddItem("Rust", 10, Color.Red)
                    .AddItem("PowerShell", 4, Color.Pink1));

            return tree;
        }
    }

    public sealed class Slide7 : SlideStep
    {
        public Slide7(TreeGuide guide)
        {
            Guide = guide;
        }

        public TreeGuide Guide { get; }

        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("[yellow]Root[/]").Guide(Guide);
            var item1 = tree.AddNode("[green]Item 1[/]");
            {
                item1.AddNode("[green]Item 1-1[/]").Collapse();
                item1.AddNode("[red]Item 1-2[/]").Collapse();
            }

            tree.AddNode("[green]Item 2[/]");

            var tableNode = tree.AddNode(new Table()
                .AddColumns("Foo", "Bar", "Baz")
                .AddRow("Qux", "Corgi", "Waldo"));

            tableNode.AddNode(
                new BreakdownChart()
                    .ShowPercentage()
                    .Compact()
                    .Width(40)
                    .AddItem("C#", 78, Color.Yellow)
                    .AddItem("F#", 8, Color.Blue)
                    .AddItem("Rust", 10, Color.Red)
                    .AddItem("PowerShell", 4, Color.Pink1));

            return tree;
        }
    }

    public sealed class Slide8 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("[yellow]Root[/]");
            var item1 = tree.AddNode("[green]Item 1[/]");
            {
                item1.AddNode("[green]Item 1-1[/]").Collapse();
                item1.AddNode("[red]Item 1-2[/]").Collapse();
            }

            tree.AddNode("[green]Item 2[/]");

            var tableNode = tree.AddNode(new Table()
                .AddColumns("Foo", "Bar", "Baz")
                .AddRow("Qux", "Corgi", "Waldo"));

            tableNode.AddNode(
                new BreakdownChart()
                    .ShowPercentage()
                    .Compact()
                    .Width(40)
                    .AddItem("C#", 78, Color.Yellow)
                    .AddItem("F#", 8, Color.Blue)
                    .AddItem("Rust", 10, Color.Red)
                    .AddItem("PowerShellz", 4, Color.Pink1));

            tree.AddNode("😎 [blink]Pretty cool huh?[/]");

            return tree;
        }
    }
}
