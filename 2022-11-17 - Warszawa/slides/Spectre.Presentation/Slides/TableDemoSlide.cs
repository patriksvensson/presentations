using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class TableDemoSlide : SlideWithSteps
{
    public override string Title { get; } = "[grey37]Features:[/] Tables (demo)";
    public override bool ShowHeader => true;

    protected override IEnumerable<SlideStep> GetSteps()
    {
        yield return new Slide1();
        yield return new Slide2();
        yield return new Slide3();
        yield return new Slide4();
        yield return new Slide5();
        yield return new Slide6();
        yield return new Slide7(TableBorder.Rounded);
        yield return new Slide7(TableBorder.Double);
        yield return new Slide7(TableBorder.HeavyHead);
        yield return new Slide7(TableBorder.HeavyEdge);
        yield return new Slide7(TableBorder.Heavy);
        yield return new Slide7(TableBorder.MinimalDoubleHead);
        yield return new Slide7(TableBorder.Minimal);
        yield return new Slide7(TableBorder.Markdown);
        yield return new Slide7(TableBorder.AsciiDoubleHead);
        yield return new Slide7(TableBorder.Ascii2);
        yield return new Slide7(TableBorder.DoubleEdge);
    }

    public sealed class Slide1 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var table = new Table();
            table.AddColumn("Column 1");
            table.AddColumn("Column 2");

            table.AddRow(new Markup("Item 1"), new Markup("Item 2"));
            table.AddRow(new Markup("Item 3"), new Markup("Item 4"));

            return table;
        }
    }

    public sealed class Slide2 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var table = new Table().Expand();
            table.AddColumn("Column 1");
            table.AddColumn("Column 2");

            table.AddRow(new Markup("Item 1"), new Markup("Item 2"));
            table.AddRow(new Markup("Item 3"), new Markup("Item 4"));

            return table;
        }
    }

    public sealed class Slide3 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
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
            table.AddRow(new Markup("Item 3"), new Panel("Hello"));

            return table;
        }
    }

    public sealed class Slide4 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
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
            table.AddRow(new Markup("Item 3"), new Panel("Hello"));

            return table;
        }
    }

    public sealed class Slide5 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
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
            table.AddRow(new Markup("Item 3"), new Panel("Hello").BorderColor(Color.Yellow));

            return table;
        }
    }

    public sealed class Slide6 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
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
            table.AddRow(new Markup("Item 3"), new Panel("Hello").BorderColor(Color.Yellow));

            return table;
        }
    }

    public sealed class Slide7 : SlideStep
    {
        public Slide7(TableBorder border)
        {
            Border = border;
        }

        public TableBorder Border { get; }

        public override IRenderable Render(IRenderable? previous)
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
            table.AddRow(new Markup("Item 3"), Align.Right(new Panel("Hello").BorderColor(Color.Yellow)));

            return table;
        }
    }
}
