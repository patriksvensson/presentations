using Spectre.Console;
using Spectre.Console.Cli;
using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Slides
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var app = new CommandApp<SlideCommand>();
            app.Run(args);
        }
    }

    public sealed class SlideCommand : Command<SlideCommand.Settings>
    {
        public sealed class Settings : CommandSettings
        {
            [CommandOption("--slide")]
            public int? Slide { get; set; }
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            Console.BufferWidth = Console.WindowWidth = 54;
            Console.BufferHeight = Console.WindowHeight = 14;

            var manager = new SlideManager(new Slide[]
            {
                new IntroSlide(),
                new AboutSlide(),
                new WordListSlide(),
                new WhatIsSpectreConsoleSlide(),
                new WhatIsNotSpectreConsole(),
                new WhatProblemsDoesItSolve(),
                new ColorsSlide(),
                new TextSlide(),
                new TablesSlide(),
                new TablesDemoIntro(),
                new TablesDemo(),
                new TreeSlide(),
                new TreeSlideIntro(),
                new TreeDemo(),
                new WhatElseSlide(),
                new DemoSlide(),
                new WhatsNextSlide(),
                new ThanksSlide(),
            });

            manager.GoToSlide(settings.Slide);

            AnsiConsole.Clear();
            AnsiConsole.Live(manager)
                .Start(context =>
                {
                    while (true)
                    {
                        context.Refresh();

                        var key = AnsiConsole.Console.Input.ReadKey(true);
                        if (key != null && key.Value.Key == ConsoleKey.Escape)
                        {
                            break;
                        }
                        else if (key != null && key.Value.Key == ConsoleKey.RightArrow)
                        {
                            manager.MoveNext();
                        }
                        else if (key != null && key.Value.Key == ConsoleKey.LeftArrow)
                        {
                            manager.MovePrevious();
                        }
                    }
                });

            return 0;
        }
    }

    public sealed class SlideManager : IRenderable
    {
        private readonly List<Slide> _slides;
        private int _slideIndex;
        private int _slideStepIndex;

        public SlideManager(IEnumerable<Slide> slides)
        {
            _slides = new List<Slide>(slides);
            _slideIndex = 0;
            _slideStepIndex = 0;
        }

        public void GoToSlide(int? slide)
        {
            if (slide != null)
            {
                slide = slide.Value - 1;
                _slideIndex = Math.Max(0, Math.Min(slide.Value, _slides.Count - 1));
                if (slide.Value != _slideIndex)
                {
                    _slideStepIndex = 0;
                }
            }
        }

        public void MoveNext()
        {
            if (_slideStepIndex < _slides[_slideIndex].Steps.Length - 1)
            {
                _slideStepIndex++;
            }
            else
            {
                var originalIndex = _slideIndex;

                _slideIndex++;
                _slideIndex = Math.Min(_slideIndex, _slides.Count - 1);

                if (originalIndex != _slideIndex)
                {
                    _slideStepIndex = 0;
                }
            }
        }

        public void MovePrevious()
        {
            if (_slideStepIndex > 0)
            {
                _slideStepIndex--;
            }
            else
            {
                var originalIndex = _slideIndex;

                _slideIndex--;
                _slideIndex = Math.Max(0, _slideIndex);

                if (originalIndex != _slideIndex)
                {
                    _slideStepIndex = _slides[_slideIndex].Steps.Length - 1;
                }
            }
        }

        public Measurement Measure(RenderContext context, int maxWidth)
        {
            return Build().Measure(context, maxWidth);
        }

        public IEnumerable<Segment> Render(RenderContext context, int maxWidth)
        {
            return Build().Render(context, maxWidth);
        }

        private IRenderable Build()
        {
            var previousSlide = _slideStepIndex >= 1
                ? GetPreviousRenderable(_slideStepIndex)
                : null;

            if (_slides[_slideIndex].ShowHeader)
            {
                var slide = _slideIndex + 1;
                var slides = _slides.Count;
                var step = _slideStepIndex + 1;
                var steps = _slides[_slideIndex].Steps.Length;

                var header = new Table().NoBorder().Expand();

                var prefix = step == 1 ? "[grey37]◀[/]" : "[grey15]◀[/]";
                var suffix = step == steps ? "[grey37 blink]▶[/]" : "[grey15]▶[/]";
                if (slide == slides)
                {
                    suffix = string.Empty;
                }


                header.AddColumn(new TableColumn($"{prefix} [yellow]{_slides[_slideIndex].Title}[/] {suffix}").LeftAligned());
                header.AddColumn(new TableColumn($"[grey37]Slide[/] {slide}[grey37]/[/]{slides}").RightAligned().PadRight(0));

                return new Rows(
                    new Padder(new Panel(header).Expand().PadTop(0).DoubleBorder(), new Padding(1, 1)),
                    new Padder(_slides[_slideIndex].Steps[_slideStepIndex].GetRenderable(previousSlide), new Padding(2, 0)));
            }
            else
            {
                var padding = _slides[_slideIndex].Padding ?? new Padding(2, 0);
                return new Padder(_slides[_slideIndex].Steps[_slideStepIndex].GetRenderable(previousSlide), padding);
            }
        }

        private IRenderable? GetPreviousRenderable(int index)
        {
            if (index <= 0)
            {
                return null;
            }

            return
                _slides[_slideIndex].Steps[index - 1].GetRenderable(
                    GetPreviousRenderable(index - 1));
        }
    }
}
