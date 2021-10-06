using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class WhatsNextSlide : Slide
    {
        public override string Title => "What's next?";
        public override bool ShowHeader => true;

        public WhatsNextSlide()
            : base(new FirstStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new FigletText("vNext")
                    .Color(Color.Yellow)
                    .Centered();
            }
        }

    }
}
