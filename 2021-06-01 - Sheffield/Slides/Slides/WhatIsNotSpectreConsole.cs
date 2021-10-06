using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class WhatIsNotSpectreConsole : Slide
    {
        public override string Title => "[red]What is it [u]NOT[/]?[/]";

        public WhatIsNotSpectreConsole()
            : base(
                  new EmptyStep(),
                  new Step10(),
                  new Step20(),
                  new Step30())
        {
        }

        public sealed class Step10 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return GetBullet(
                    "A TUI [i grey](Terminal UI)[/] library\n"
                    );
            }
        }

        public sealed class Step20 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet("No mouse support or clickable buttons\n"));
            }
        }

        public sealed class Step30 : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet("No automatic redrawing of widgets"));
            }
        }
    }
}
