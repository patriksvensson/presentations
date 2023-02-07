using System;
using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

internal sealed class ProgressBar : Renderable
{
    public double Value { get; set; }
    public double MaxValue { get; set; } = 100;

    public int? Width { get; set; }
    public bool ShowRemaining { get; set; } = true;
    public char UnicodeBar { get; set; } = '━';
    public char AsciiBar { get; set; } = '-';

    public Style CompletedStyle { get; set; } = new Style(foreground: Color.Yellow);
    public Style FinishedStyle { get; set; } = new Style(foreground: Color.Green);
    public Style RemainingStyle { get; set; } = new Style(foreground: Color.Grey);

    protected override Measurement Measure(RenderOptions options, int maxWidth)
    {
        var width = Math.Min(Width ?? maxWidth, maxWidth);
        return new Measurement(4, width);
    }

    protected override IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
    {
        var width = Math.Min(Width ?? maxWidth, maxWidth);
        var completedBarCount = Math.Min(MaxValue, Math.Max(0, Value));
        var isCompleted = completedBarCount >= MaxValue;

        var bar = !options.Unicode ? AsciiBar : UnicodeBar;
        var style = isCompleted ? FinishedStyle : CompletedStyle;
        var barCount = Math.Max(0, (int)(width * (completedBarCount / MaxValue)));

        if (barCount < 0)
        {
            yield break;
        }

        yield return new Segment(new string(bar, barCount), style);

        // More space available?
        if (barCount < width)
        {
            var diff = width - barCount;

            var legacy = options.ColorSystem == ColorSystem.NoColors || options.ColorSystem == ColorSystem.Legacy;
            var remainingToken = ShowRemaining && !legacy ? bar : ' ';
            yield return new Segment(new string(remainingToken, diff), RemainingStyle);
        }
    }
}
