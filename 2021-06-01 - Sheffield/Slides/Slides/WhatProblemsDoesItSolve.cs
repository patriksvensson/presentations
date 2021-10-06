using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class WhatProblemsDoesItSolve : Slide
    {
        public override string Title => "What problems does it solve";

        public WhatProblemsDoesItSolve()
            : base(
                  new FirstStep(),
                  new SecondStep(),
                  new ThirdStep(),
                  new FourthStep(),
                  new FifthStep(),
                  new SixthStep(),
                  new SeventhStep(),
                  new EightStep(),
                  new NinethStep(),
                  new TenthStep(),
                  new EleventhStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return GetBullet(
                    "Makes it easy to display static or semi-static rich content " +
                    "Such as [green]tables[/], [green]trees[/], [green]progress bars[/], [green]formatted text[/], [green]prompts[/], [green]charts[/] " + 
                    "and a lot more!\n");
            }
        }

        public sealed class SecondStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "Makes it easy to parse arguments passed to your application"));
            }
        }

        public sealed class ThirdStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var tree = new Tree("■ [yellow]Hides a lot of complexity[/]");

                return tree;
            }
        }

        public sealed class FourthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var tree = new Tree("■ Hides a lot of complexity\n│");
                tree.AddNode("[yellow]ANSI/VT code generation[/]");

                return tree;
            }
        }

        public sealed class FifthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var tree = new Tree("■ Hides a lot of complexity\n│");
                tree.AddNode("ANSI/VT code generation");
                tree.AddNode("[yellow]Detection of terminal capabilities[/]");

                return tree;
            }
        }

        public sealed class SixthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var tree = new Tree("■ Hides a lot of complexity\n│");
                tree.AddNode("ANSI/VT code generation");

                var detection = tree.AddNode("Detection of terminal capabilities");
                detection.AddNode("[yellow]Does this terminal support VT/ANSI sequences?[/]");

                return tree;
            }
        }

        public sealed class SeventhStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var tree = new Tree("■ Hides a lot of complexity\n│");
                tree.AddNode("ANSI/VT code generation");

                var detection = tree.AddNode("Detection of terminal capabilities");
                detection.AddNode("Does this terminal support VT/ANSI sequences?");
                detection.AddNode("[yellow]What color system does the terminal use?[/]");

                return tree;
            }
        }

        public sealed class EightStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        public sealed class NinethStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        public sealed class TenthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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

        public sealed class EleventhStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
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
}
