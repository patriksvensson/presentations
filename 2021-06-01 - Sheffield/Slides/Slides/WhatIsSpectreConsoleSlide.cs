using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class WhatIsSpectreConsoleSlide : Slide
    {
        public override string Title => "What is Spectre.Console?";

        public WhatIsSpectreConsoleSlide()
            : base(
                  new EmptyStep(),
                  new FirstStep(),
                  new ThirdStep(),
                  new FourthStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "A .NET library that makes it [u blue]easy[/]\nto create " + 
                    "[red]b[/][blue]e[/][green]a[/][yellow]u[/][orange1]t[/][red]i[/][green]f[/][blue]u[/][yellow]l[/] " + 
                    "console applications\n"));
            }
        }

        public sealed class ThirdStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "Targets [yellow]net5.0[/] and [yellow]netstandard2.0[/]\n"));
            }
        }

        public sealed class FourthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "Inspired by [blue]Rich[/] for [green]Python[/] 🐍"));
            }
        }
    }
}
