using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public sealed class WordListSlide : Slide
    {
        public override string Title => "Good to know";

        public WordListSlide()
            : base(
                  new FirstStep(),
                  new SecondStep(),
                  new ThirdStep(),
                  new FourthStep(),
                  new FifthStep(),
                  new SixthStep(),
                  new SeventhStep())
        {
        }

        public sealed class FirstStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var root = new Tree("■ [yellow]Console[/]\n│");
                root.AddNode("Originally meant the physical device; a screen and a keyboard 💻\n");
                root.AddNode("Nowadays, it’s used synonymous with...");

                return root;
            }
        }

        public sealed class SecondStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var root = new Tree("■ [yellow]Terminal[/]\n│");
                root.AddNode("Originally meant a TTY [italic](teletypewriter)[/]\n");
                root.AddNode("Nowadays, we use it about [green]software that displays text output[/]");

                return root;
            }
        }

        public sealed class ThirdStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var root = new Tree("■ [yellow]Shell[/]\n│");
                root.AddNode("An interface running [italic]\"on top\"[/] of the terminal, executing commands\n");
                root.AddNode("[gray]Examples:[/] [blue]bash[/], [blue]zsh[/], [blue]PowerShell[/], [blue]pwsh[/], [blue]cmd[/]");

                return root;
            }
        }

        public sealed class FourthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var root = new Tree("■ [yellow]CLI[/] / [yellow]Command-line Interface[/]\n│");
                root.AddNode("An application that accepts text input from the command line\n");

                return root;
            }
        }

        public sealed class FifthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var root = new Tree("■ [yellow]CLI[/] / [yellow]Command-line Interface[/]\n│");
                root.AddNode("An application that accepts text input from the command line\n");
                root.AddNode("[gray]Example:[/] [blue]git commit -m [green]'Lol'[/][/]");

                return root;
            }
        }

        public sealed class SixthStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var root = new Tree("■ [yellow]CLI[/] / [yellow]Command-line Interface[/]\n│");
                root.AddNode("An application that accepts text input from the command line\n");
                root.AddNode("[gray]Example:[/] [yellow]git[/] [grey37]commit -m 'Lol'[/]\n         [yellow]^^^[/] [yellow]Executable[/]");

                return root;
            }
        }

        public sealed class SeventhStep : SlideStep
        {
            public override IRenderable GetRenderable(IRenderable? previous)
            {
                var root = new Tree("■ [yellow]CLI[/] / [yellow]Command-line Interface[/]\n│");
                root.AddNode("An application that accepts text input from the command line\n");
                root.AddNode("[gray]Example:[/] [grey37]git[/] [yellow]commit -m 'Lol'[/]\n             [yellow]^^^^^^^^^^^^^^^[/] [yellow]Text[/]");

                return root;
            }
        }
    }
}
