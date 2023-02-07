using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class WhatProblemsDoesItSolve : SlideWithSteps
{
    public override string Title { get; } = "What problems does it solve?";

    protected override IEnumerable<SlideStep> GetSteps()
    {
        yield return new Slide1();
        yield return new Slide2();
        yield return new Slide3();
        yield return new Slide4();
        yield return new Slide5();
        yield return new Slide6();
        yield return new Slide7();
        yield return new Slide8();
        yield return new Slide9();
        yield return new Slide10();
        yield return new Slide11();
    }

    public sealed class Slide1 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Bullet(new Markup(
                "Makes it easy to display static or semi-static rich content " +
                "Such as [green]tables[/], [green]trees[/], [green]progress bars[/], [green]formatted text[/], [green]prompts[/], [green]charts[/] " +
                "and a lot more!\n"));
        }
    }

    public sealed class Slide2 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            return new Rows(
                previous!,
                new Bullet(new Markup(
                    "Makes it easy to parse arguments passed to your application\n")));
        }
    }

    public sealed class Slide3 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity");

            return tree;
        }
    }

    public sealed class Slide4 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity\n│");
            tree.AddNode("ANSI/VT code generation");

            return tree;
        }
    }

    public sealed class Slide5 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity\n│");
            tree.AddNode("ANSI/VT code generation");
            tree.AddNode("[yellow]Detection of terminal capabilities[/]");

            return tree;
        }
    }

    public sealed class Slide6 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity\n│");
            tree.AddNode("ANSI/VT code generation");

            var detection = tree.AddNode("Detection of terminal capabilities");
            detection.AddNode("[yellow]Does this terminal support VT/ANSI sequences?[/]");

            return tree;
        }
    }

    public sealed class Slide7 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity\n│");
            tree.AddNode("ANSI/VT code generation");

            var detection = tree.AddNode("Detection of terminal capabilities");
            detection.AddNode("Does this terminal support VT/ANSI sequences?");
            detection.AddNode("[yellow]What color system does the terminal use?[/]");

            return tree;
        }
    }

    public sealed class Slide8 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity\n│");
            tree.AddNode("ANSI/VT code generation");

            var detection = tree.AddNode("Detection of terminal capabilities");
            detection.AddNode("Does this terminal support VT/ANSI sequences?");
            detection.AddNode("What color system does the terminal use?");
            detection.AddNode("[yellow]Are we even writing to a terminal?[/]");

            return tree;
        }
    }

    public sealed class Slide9 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity\n│");
            tree.AddNode("ANSI/VT code generation");

            var detection = tree.AddNode("Detection of terminal capabilities");
            detection.AddNode("Does this terminal support VT/ANSI sequences?");
            detection.AddNode("What color system does the terminal use?");
            detection.AddNode("Are we even writing to a terminal?");
            detection.AddNode("[yellow]Is Unicode supported?[/]");

            return tree;
        }
    }

    public sealed class Slide10 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity\n│");
            tree.AddNode("ANSI/VT code generation");

            var detection = tree.AddNode("Detection of terminal capabilities");
            detection.AddNode("Does this terminal support VT/ANSI sequences?");
            detection.AddNode("What color system does the terminal use?");
            detection.AddNode("Are we even writing to a terminal?");
            detection.AddNode("Is Unicode supported?");
            detection.AddNode("[yellow]How many cells does this character occupy?[/]");

            return tree;
        }
    }

    public sealed class Slide11 : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var tree = new Tree("■ Hides a lot of complexity\n│");
            tree.AddNode("ANSI/VT code generation");

            var detection = tree.AddNode("Detection of terminal capabilities");
            detection.AddNode("Does this terminal support VT/ANSI sequences?");
            detection.AddNode("What color system does the terminal use?");
            detection.AddNode("Are we even writing to a terminal?");
            detection.AddNode("Is Unicode supported?");
            detection.AddNode("How many cells does this character occupy?");

            var complex = detection.AddNode("[yellow]Is the current terminal suitable to display complex things?[/]");
            complex.AddNode("▶ [blue]Status displays or progress bars[/]");
            complex.AddNode("▶ [blue]Live updates[/]");
            complex.AddNode("▶ [blue]Dynamic prompts[/]");

            return tree;
        }
    }
}
