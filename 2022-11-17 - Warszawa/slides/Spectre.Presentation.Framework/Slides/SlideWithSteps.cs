using System;
using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Spectre.Presentation.Framework;

public abstract class SlideWithSteps : Slide
{
    private readonly List<IRenderable> _steps;
    private int _index;

    public override (int, int)? Progress => (_index + 1, _steps.Count);

    protected SlideWithSteps()
    {
        _steps = new List<IRenderable>();
        _steps.Add(new Text(string.Empty));

        var current = default(IRenderable);
        foreach (var step in GetSteps())
        {
            var previous = current;
            current = step.Render(current);
            if (current == previous)
            {
                throw new InvalidOperationException("Each slide step needs to produce an unique IRenderable");
            }

            _steps.Add(current);
        }
    }

    protected abstract IEnumerable<SlideStep> GetSteps();

    protected override IRenderable GetRenderable()
    {
        return _steps[_index];
    }

    public override bool Previous()
    {
        if (_index > 0)
        {
            _index--;
            return true;
        }

        return false;
    }

    public override bool Next()
    {
        if (_index < _steps.Count - 1)
        {
            _index++;
            return true;
        }

        return false;
    }
}
