using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class ThanksSlide : Slide
    {
        public override string Title => "Questions?";
        public override bool ShowHeader => true;

        public ThanksSlide()
            : base(new FirstStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new FigletText("Thanks!")
                    .Color(Color.Yellow)
                    .Centered();
            }
        }

    }
}
