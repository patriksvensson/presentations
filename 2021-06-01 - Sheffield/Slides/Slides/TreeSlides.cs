using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public class TreeSlide : Slide
    {
        public override string Title => "Trees";

        public TreeSlide()
            : base(
                  new EmptyStep(),
                  new FirstStep(),
                  new ThirdStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return GetBullet("Used to represent hierarchical data\n");
            }
        }

        public sealed class ThirdStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet("Also supports nesting of [blue]IRenderable[/]:s"));
            }
        }
    }

    public class TreeSlideIntro : Slide
    {
        public override string Title => "[grey37]Demo:[/] Trees";
        public override bool ShowHeader => true;

        public TreeSlideIntro()
            : base(new EmptyStep())
        {
        }
    }

    public class TreeDemo : Slide
    {
        public override string Title => "Tables (demo)";
        public override bool ShowHeader => false;
        public override Padding? Padding => new Padding(0);

        public TreeDemo()
            : base(
                  new Step0(), new Step10(), new Step20(),
                  new Step30(), new Step40(), new Step50(),
                  new Step60(), new Step70(),
                  new Step80(TreeGuide.Ascii),
                  new Step80(TreeGuide.BoldLine),
                  new Step80(TreeGuide.DoubleLine),
                  new Step80(TreeGuide.Line))
        {
        }
        public sealed class Step0 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        public sealed class Step10 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        // COLLAPSE #1
        public sealed class Step20 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        // COLLAPSE #2
        public sealed class Step30 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        // TABLE
        public sealed class Step40 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        // TABLE + BAR
        public sealed class Step50 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        // TABLE + BAR COLLAPSED
        public sealed class Step60 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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
                    .AddRow("Qux", "Corgi", "Waldo")).Collapse();

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

        // TABLE + BAR COLLAPSED
        public sealed class Step70 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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
                    .AddRow("Qux", "Corgi", "Waldo")).Collapse();

                tree.AddNode("😎 Pretty cool huh?");

                return tree;
            }
        }

        // TABLE + BAR COLLAPSED
        public sealed class Step80 : SlideStep
        {
            public Step80(TreeGuide guide)
            {
                Guide = guide;
            }

            public TreeGuide Guide { get; }

            public override IRenderable GetRenderable(IRenderable? previous)
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
                    .AddRow("Qux", "Corgi", "Waldo")).Collapse();

                tree.AddNode("😎 Pretty cool huh?");

                return tree;
            }
        }
    }
}
