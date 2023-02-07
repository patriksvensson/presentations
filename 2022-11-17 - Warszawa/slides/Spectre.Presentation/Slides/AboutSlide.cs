using System.Collections.Generic;
using SixLabors.ImageSharp;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class AboutSlide : SplitSlide
{
    private readonly CanvasImage _image;
    public override string Title { get; } = "Who am I?";

    public AboutSlide()
    {
        _image = new CanvasImage("Resources/avatar.png");
    }

    protected override IEnumerable<IRenderable> GetRenderables()
    {
        yield return new Markup("My name is [yellow]Patrik Svensson[/]");
        yield return new Markup("From [blue]Sweden[/], living outside of [blue]Stockholm[/]");
        yield return new Markup("Father to [yellow]Ada 👧[/]\nHusband to [yellow]Valentina 👩[/]");
        yield return new Markup("Freelancing [blue]programmer[/]\nCurrently working for a company called [blue]Mitigram[/]");
        yield return new Markup("Creator of [link=https://spectreconsole.net blue]Spectre.Console[/] 👻");
        yield return new Markup("Creator of the build tool [link=https://cakebuild.net blue]Cake[/] 🍰");
        yield return new Markup("Microsoft [black on blue]MVP[/]");
        yield return new Markup("GitHub Star 🌟");
    }

    protected override IRenderable GetRightRenderable()
    {
        return Align.Center(_image, VerticalAlignment.Middle);
    }
}

public abstract class SplitSlide : BulletSlide
{
    public SplitSlide()
    {
    }

    protected abstract IRenderable GetRightRenderable();

    protected override IRenderable GetRenderable()
    {
        var layout = new Layout()
            .SplitColumns(
                new Layout("Left"),
                new Layout("Right"));

        layout["Left"].Update(new AutoScroller(new Padder(base.GetRenderable(), Padding)));
        layout["Right"].Update(GetRightRenderable());

        return layout;
    }
}