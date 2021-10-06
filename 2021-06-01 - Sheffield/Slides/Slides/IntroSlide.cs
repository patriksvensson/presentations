using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class IntroSlide : Slide
    {
        public override string Title => "Spectre.Console";
        public override bool ShowHeader => false;
        public override Padding? Padding => new Padding(0);

        public IntroSlide()
            : base(new FirstStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            private readonly CanvasImage _image;

            public FirstStep()
            {
                _image = new CanvasImage("logo.png");
            }

            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return _image;
            }
        }

    }
}
