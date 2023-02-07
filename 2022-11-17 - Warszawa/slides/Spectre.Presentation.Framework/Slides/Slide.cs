using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

public abstract class Slide : Renderable
{
    public virtual bool ShowHeader { get; } = true;
    public virtual bool ShowFooter { get; } = true;

    public virtual (int, int)? Progress { get; } = null;

    public abstract string Title { get; }

    public virtual Padding Padding { get; } = new Padding(2, 1, 2, 0);

    protected abstract IRenderable GetRenderable();

    protected override IEnumerable<Segment> Render(RenderOptions options, int maxWidth)
    {
        var p = new Padder(GetRenderable(), Padding);
        return ((IRenderable)p).Render(options, maxWidth);
    }

    public virtual bool Previous()
    {
        return false;
    }

    public virtual bool Next()
    {
        return false;
    }
}
