using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class DemoSlide : Slide
    {
        public override string Title => "Demo";
        public override bool ShowHeader => true;

        public DemoSlide()
            : base(new FirstStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new FigletText("Demo")
                    .Color(Color.Green)
                    .Centered();
            }
        }

    }
}
