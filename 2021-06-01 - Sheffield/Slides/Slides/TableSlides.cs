using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public class TablesSlide : Slide
    {
        public override string Title => "Tables";

        public TablesSlide()
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
                return GetBullet("Used to represent tabular data\n");
            }
        }

        public sealed class SecondStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet("Implements [blue]IRenderable[/]\n"));
            }
        }

        public sealed class ThirdStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet("Supports nesting of [blue]IRenderable[/]"));
            }
        }
    }

    public class TablesDemoIntro : Slide
    {
        public override string Title => "[grey37]Demo:[/] Tables";
        public override bool ShowHeader => true;

        public TablesDemoIntro()
            : base(new EmptyStep())
        {
        }
    }

    public class TablesDemo : Slide
    {
        public override string Title => "Tables (demo)";
        public override bool ShowHeader => false;
        public override Padding? Padding => new Padding(0);

        public TablesDemo()
            : base(new Step01(), new Step0(), new Step1(), new Step2(), new Step3(), new Step4(), 
                  new Step5(TableBorder.Rounded),
                  new Step5(TableBorder.Double),
                  new Step5(TableBorder.HeavyHead),
                  new Step5(TableBorder.HeavyEdge),
                  new Step5(TableBorder.Heavy),
                  new Step5(TableBorder.MinimalDoubleHead),
                  new Step5(TableBorder.Minimal),
                  new Step5(TableBorder.Markdown),
                  new Step5(TableBorder.AsciiDoubleHead),
                  new Step5(TableBorder.Ascii2),
                  new Step5(TableBorder.DoubleEdge))
        {
        }

        public sealed class Step01 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var table = new Table();
                table.AddColumn("Column 1");
                table.AddColumn("Column 2");

                table.AddRow(new Markup("Item 1"), new Markup("Item 2"));
                table.AddRow(new Markup("Item 3"), new Markup("Item 4"));

                return table;
            }
        }

        public sealed class Step0 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var table = new Table().Expand();
                table.AddColumn("Column 1");
                table.AddColumn("Column 2");

                table.AddRow(new Markup("Item 1"), new Markup("Item 2"));
                table.AddRow(new Markup("Item 3"), new Markup("Item 4"));

                return table;
            }
        }

        public sealed class Step1 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var table = new Table().Expand();
                table.AddColumn("Column 1");
                table.AddColumn("Column 2");

                var secondTable = new Table();
                secondTable.AddColumn("ID");
                secondTable.AddColumn("Score");
                secondTable.AddRow("1", "32");
                secondTable.AddRow("2", "78");

                var chart = new BarChart();
                chart.Label("Item 4");
                chart.LeftAlignLabel();
                chart.AddItem("Foo", 6);
                chart.AddItem("Bar", 12);

                table.AddRow(new Markup("Item 1"), new Rows(new Markup("Item 2"), secondTable));
                table.AddRow(new Markup("Item 3"), chart );

                return table;
            }
        }

        public sealed class Step2 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var table = new Table().Expand();
                table.AddColumn("Column 1");
                table.AddColumn("Column 2", c => c.Centered());

                var secondTable = new Table().Centered();
                secondTable.AddColumn("ID");
                secondTable.AddColumn("Score");
                secondTable.AddRow("1", "32");
                secondTable.AddRow("2", "78");

                var chart = new BarChart();
                chart.Label("Item 4");
                chart.LeftAlignLabel();
                chart.AddItem("Foo", 6);
                chart.AddItem("Bar", 12);

                table.AddRow(new Markup("Item 1"), new Rows(new Markup("Item 2"), secondTable));
                table.AddRow(new Markup("Item 3"), chart);

                return table;
            }
        }

        public sealed class Step3 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var table = new Table().Expand().BorderColor(Color.Yellow);
                table.AddColumn("Column 1");
                table.AddColumn("Column 2", c => c.Centered());

                var secondTable = new Table().BorderColor(Color.Blue).Centered();
                secondTable.AddColumn("ID");
                secondTable.AddColumn("Score");
                secondTable.AddRow("1", "32");
                secondTable.AddRow("2", "78");

                var chart = new BarChart();
                chart.Label("Item 4");
                chart.LeftAlignLabel();
                chart.AddItem("Foo", 6);
                chart.AddItem("Bar", 12);

                table.AddRow(new Markup("Item 1"), new Rows(new Markup("Item 2"), secondTable));
                table.AddRow(new Markup("Item 3"), chart);

                return table;
            }
        }

        public sealed class Step4 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var table = new Table().Expand().BorderColor(Color.Yellow);
                table.AddColumn("[red]Column 1[/]");
                table.AddColumn("[green]Column 2[/]", c => c.Centered());

                var secondTable = new Table().BorderColor(Color.Blue).Centered();
                secondTable.AddColumn("[grey37]ID[/]");
                secondTable.AddColumn("[grey37]Score[/]");
                secondTable.AddRow("1", "[red]32[/]");
                secondTable.AddRow("2", "[green]78[/]");

                var chart = new BarChart();
                chart.Label("Item 4");
                chart.LeftAlignLabel();
                chart.AddItem("Foo", 6, Color.Red);
                chart.AddItem("Bar", 12, Color.Yellow);

                table.AddRow(new Markup("Item 1"), new Rows(new Markup("Item 2"), secondTable));
                table.AddRow(new Markup("Item 3"), chart);

                return table;
            }
        }

        public sealed class Step5 : SlideStep
        {
            public Step5(TableBorder border)
            {
                Border = border;
            }

            public TableBorder Border { get; }

            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var table = new Table().Expand().Border(Border).BorderColor(Color.Yellow);
                table.AddColumn("[red]Column 1[/]");
                table.AddColumn("[green]Column 2[/]", c => c.Centered());

                var secondTable = new Table().RoundedBorder().BorderColor(Color.Blue).Centered();
                secondTable.AddColumn("[grey37]ID[/]");
                secondTable.AddColumn("[grey37]Score[/]");
                secondTable.AddRow("1", "[red]32[/]");
                secondTable.AddRow("2", "[green]78[/]");

                var chart = new BarChart();
                chart.Label("Item 4");
                chart.LeftAlignLabel();
                chart.AddItem("Foo", 6, Color.Red);
                chart.AddItem("Bar", 12, Color.Green);

                table.AddRow(new Markup("Item 1"), new Rows(new Markup("Item 2"), secondTable));
                table.AddRow(new Markup("Item 3"), chart);

                return table;
            }
        }
    }
}
