using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class EmptyStep : SlideStep
    {
        public override IRenderable GetRenderable(IRenderable previous)
        {
            return Text.Empty;
        }
    }

    public abstract class AboutStep : SlideStep
    {
    }

    public sealed class AboutSlide : Slide
    {
        public override string Title => "Who am I?";

        public AboutSlide()
            : base(
                  new EmptyStep(),
                  new FirstStep(),
                  new SecondStep(),
                  new ThirdStep(),
                  new FourthStep(),
                  new FifthStep(),
                  new SixthStep(),
                  new SeventhStep())
        {
        }



        public sealed class FirstStep : AboutStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return GetBullet("My name is [yellow]Patrik Svensson[/]");
            }
        }

        public sealed class SecondStep : AboutStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "From [blue]Sweden[/], living outside of [blue]Stockholm[/]"));
            }
        }

        public sealed class ThirdStep : AboutStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "Father to [yellow]Ada 👧[/], husband to [yellow]Valentina 👩[/]"));
            }
        }

        public sealed class FourthStep : AboutStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "Freelancing [blue]programmer[/]\nWorking for a company called [blue]Mitigram[/]"));
            }
        }

        public sealed class FifthStep : AboutStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "Creator of the build tool [link=https://cakebuild.net blue]Cake[/] 🍰"));
            }
        }

        public sealed class SixthStep : AboutStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "Microsoft [black on blue]MVP[/]"));
            }
        }

        public sealed class SeventhStep : AboutStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                return new Rows(previous, GetBullet(
                    "GitHub Star 🌟"));
            }
        }
    }
}
