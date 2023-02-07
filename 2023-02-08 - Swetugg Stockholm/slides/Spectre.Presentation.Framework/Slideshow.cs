using System;
using System.Collections.Generic;
using System.Diagnostics;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

public sealed class Slideshow : Renderable
{
    private readonly List<Slide> _slides;
    private readonly Layout _layout;
    private readonly IClicker _clicker;
    private int _index;

    public Slideshow(IClicker clicker, IEnumerable<Slide> slides)
    {
        _clicker = clicker ?? throw new ArgumentNullException(nameof(clicker));
        _slides = new List<Slide>(slides);
        _layout = new Layout()
            .SplitRows(
                new Layout("Header")
                    .Size(3)
                    .SplitColumns(
                        new Layout("Title"),
                        new Layout("Info").Size(15)),
                new Layout("Slides"),
                new Layout("Footer").Size(2));
    }

    public static void Run(IEnumerable<Slide> slides)
    {
        try
        {
            AnsiConsole.Cursor.Hide();
            var clicker = new StdinClicker();
            var presentation = new Slideshow(clicker, slides);
            presentation.Run();
        }
        finally
        {
            AnsiConsole.Cursor.Show();
        }
    }

    public static void Run(IClicker clicker, IEnumerable<Slide> slides)
    {
        var presentation = new Slideshow(clicker, slides);
        presentation.Run();
    }

    public void Run()
    {
        AnsiConsole.AlternateScreen(() =>
        {
            AnsiConsole.Live(this).Start(ctx =>
            {
                while (true)
                {
                    var slide = GetCurrentSlide();

                    // Update visibility
                    _layout["Header"].IsVisible = slide.ShowHeader;
                    _layout["Footer"].IsVisible = slide.ShowFooter;

                    // Update slide title
                    _layout["Title"].Update(
                        new Panel(
                            new Markup(slide.Title))
                        .BorderColor(Color.Grey39)
                        .RoundedBorder()
                        .Expand());

                    // Got slide progress?
                    var progress = slide.Progress;
                    if (progress != null)
                    {
                        _layout["Footer"].Update(
                            new Padder(
                            new Grid()
                            .AddColumn()
                            .AddColumn(new GridColumn().RightAligned())
                            .AddRow(
                                new ProgressBar()
                                {
                                    Value = progress.Value.Item1,
                                    MaxValue = progress.Value.Item2,
                                },
                                new Markup($"{progress.Value.Item1}/{progress.Value.Item2}")),
                            new Padding(2, 1, 0, 0)));
                    }
                    else
                    {
                        _layout["Footer"].IsVisible = false;
                    }

                    // Update slide information
                    _layout["Info"].Update(
                        new Panel(
                            new Markup($"[grey]Slide[/] {_index + 1}[grey]/[/]{_slides.Count}")
                                .Centered())
                        .BorderColor(Color.Grey39)
                        .RoundedBorder()
                        .Expand());

                    if (slide is AnimatedSlide animated)
                    {
                        while (!_clicker.HasActivity())
                        {
                            // Update the slide content
                            _layout["Slides"].Update(slide);

                            // Refresh the presentation
                            ctx.Refresh();

                            var watch = new Stopwatch();
                            watch.Start();
                            while (!_clicker.HasActivity())
                            {
                                if (watch.Elapsed > animated.Delay)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        // Update the slide content
                        _layout["Slides"].Update(new AutoScroller(slide));

                        // Refresh the presentation
                        ctx.Refresh();
                    }

                    // Wait for activity
                    var activity = _clicker.WaitForActivity();
                    if (activity == ClickActivity.Exit)
                    {
                        break;
                    }

                    // Next?
                    if (activity == ClickActivity.Next)
                    {
                        if (slide != null)
                        {
                            if (!slide.Next())
                            {
                                if (_index < _slides.Count - 1)
                                {
                                    _index++;
                                }
                            }
                        }
                    }

                    // Previous?
                    if (activity == ClickActivity.Previous)
                    {
                        if (slide != null)
                        {
                            if (!slide.Previous())
                            {
                                if (_index > 0)
                                {
                                    _index--;
                                }
                            }
                        }
                    }
                }
            });
        });
    }

    protected override IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
    {
        return ((IRenderable)_layout).Render(options, maxWidth);
    }

    private Slide GetCurrentSlide()
    {
        if (_index >= _slides.Count)
        {
            throw new InvalidOperationException("Exceeded maximum slide count");
        }

        return _slides[_index];
    }
}