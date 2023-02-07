using System;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class RickRollSlide : AnimatedSlide
{
    private readonly SixLabors.ImageSharp.Image _image;
    private readonly bool _showHeader;
    private int _frame;

    public override string Title { get; } = "Animations";
    public override TimeSpan Delay { get; } = TimeSpan.FromMilliseconds(75);
    public override Padding Padding { get; } = new Padding(0, 0);

    public override bool ShowHeader => _showHeader;
    public override bool ShowFooter => _showHeader;

    public RickRollSlide(bool showHeader = true)
    {
        _image = SixLabors.ImageSharp.Image.Load("Resources/rickroll.gif", new SixLabors.ImageSharp.Formats.Gif.GifDecoder());
        _frame = 0;
        _showHeader = showHeader;
    }

    protected override IRenderable GetRenderable()
    {
        if (_frame >= _image.Frames.Count)
        {
            _frame = 0;
        }

        var frame = _image.Frames.CloneFrame(_frame);
        var canvasImage = new Pixels(frame);

        _frame++;

        return Align.Center(canvasImage, VerticalAlignment.Middle);
    }
}
