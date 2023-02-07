using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class LayoutSlide : SlideWithSteps
{
    public override string Title { get; } = "[grey37]Features:[/] Layouts";

    protected override IEnumerable<SlideStep> GetSteps()
    {
        yield return new Slide1();
        yield return new Slide2();
        yield return new Slide3();
        yield return new Slide4();
        yield return new Slide5();
        yield return new Slide6();
    }

    public sealed class Slide1 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Layout();
        }
    }

    public sealed class Slide2 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Layout()
                .SplitRows(
                    new Layout(),
                    new Layout());
        }
    }

    public sealed class Slide3 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Layout()
                .SplitRows(
                    new Layout()
                        .SplitColumns(
                            new Layout(),
                            new Layout()),
                    new Layout());
        }
    }

    public sealed class Slide4 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Layout()
                .SplitRows(
                    new Layout()
                        .SplitColumns(
                            new Layout(),
                            new Layout()),
                    new Layout()
                        .SplitColumns(
                            new Layout(),
                            new Layout()));
        }
    }

    public sealed class Slide5 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Layout()
                .SplitColumns(
                    new Layout().Size(5),
                    new Layout().SplitRows(
                        new Layout()
                            .SplitColumns(
                                new Layout(),
                                new Layout()),
                        new Layout()
                            .SplitColumns(
                                new Layout(),
                                new Layout())));
        }
    }

    public sealed class Slide6 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Layout()
                .SplitColumns(
                    new Layout().Size(5),
                    new Layout().SplitRows(
                        new Layout()
                            .SplitColumns(
                                new Layout(),
                                new Layout()),
                        new Layout()
                            .SplitColumns(
                                new Layout(),
                                new Layout())),
                    new Layout().Size(5));
        }
    }
}
