using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

public sealed class AutoScroller : Renderable
{
    private readonly IRenderable _child;

    public AutoScroller(IRenderable child)
    {
        _child = child ?? throw new ArgumentNullException(nameof(child));
    }

    protected override IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
    {
        var segments = _child.Render(options, maxWidth);

        if (options.Height == null)
        {
            return segments;
        }

        var lines = Segment.SplitLines(segments, maxWidth);
        if (lines.Count > options.Height)
        {
            var truncated = lines.Skip(lines.Count - options.Height.Value);
            return new SegmentLineEnumerator(truncated);
        }

        return new SegmentLineEnumerator(lines);
    }
}
