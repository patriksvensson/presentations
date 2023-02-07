using System;

namespace Spectre.Presentation.Framework;

public abstract class AnimatedSlide : Slide
{
    public virtual TimeSpan Delay { get; } = TimeSpan.FromMilliseconds(500);
}
