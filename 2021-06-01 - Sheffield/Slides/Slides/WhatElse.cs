using Spectre.Console;
using Spectre.Console.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Slides
{
    public sealed class WhatElseSlide : Slide
    {
        public override string Title => "What else can it do?";

        public WhatElseSlide()
            : base(
                  new EmptyStep(),
                  new FirstStep(1),
                  new FirstStep(2),
                  new FirstStep(3),
                  new FirstStep(4),
                  new FirstStep(5),
                  new FirstStep(6),
                  new FirstStep(7),
                  new FirstStep(8),
                  new FirstStep(9),
                  new FirstStep(10),
                  new FirstStep(11),
                  new FirstStep(12),
                  new FirstStep(13),
                  new FirstStep(14),
                  new FirstStep(15),
                  new FirstStep(16),
                  new FirstStep(17),
                  new FirstStep(18),
                  new FirstStep(19),
                  new FirstStep(20),
                  new FirstStep(21),
                  new FirstStep(22),
                  new FirstStep(23))
        {
        }

        public sealed class FirstStep : SlideStep
        {
            private readonly List<string> _items = new List<string>
            {
                "Tables", "Trees", "Canvas rendering", "Image renderering", "Pretty exception rendering",
                "Live display", "Progess display", "Status display", 
                "Text prompts", "Selection prompts", "Multi-selection prompts",
                "Bar charts", "Breakdown charts", "Horizontal lines", "Calendars", 
                "Figlet text renderering", "Command Line Parsing", "Panels",
                "Row Layouts", "Column Layouts", "Rich markup", "Colors", "Much more...",
            };

            public FirstStep(int count)
            {
                Count = count;
            }

            public int Count { get; }

            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return GetBullet(_items.Take(Count).ToArray());
            }
        }

        public sealed class SecondStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "Makes it [u blue]easy[/] to create " + 
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
