using System;
using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

public abstract class BulletSlide : SlideWithSteps
{
    protected abstract IEnumerable<IRenderable> GetRenderables();

    protected sealed override IEnumerable<SlideStep> GetSteps()
    {
        foreach (var renderable in GetRenderables())
        {
            yield return new BulletSlideStep(renderable);
        }
    }

    private sealed class BulletSlideStep : SlideStep
    {
        private readonly IRenderable _renderable;

        public BulletSlideStep(IRenderable renderable)
        {
            _renderable = renderable ?? throw new ArgumentNullException(nameof(renderable));
        }

        public override IRenderable Render(IRenderable? previous)
        {
            if (previous == null)
            {
                return new Rows(new Bullet(_renderable), new Text(string.Empty));
            }

            return new Rows(previous!, new Bullet(_renderable), new Text(string.Empty));
        }
    }
}