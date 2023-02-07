using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class WordlistSlide : SlideWithSteps
{
    public override string Title { get; } = "Good to know";

    protected override IEnumerable<SlideStep> GetSteps()
    {
        yield return new First();
        yield return new Second();
        yield return new Third();
        yield return new Fourth();
        yield return new Fifth();
        yield return new Sixth();
        yield return new Seventh();
    }

    private sealed class First : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var root = new Tree("■ [yellow]Console[/]\n│");
            root.AddNode("Originally meant the physical device; a screen and a keyboard 💻\n");
            root.AddNode("Nowadays, it’s used synonymous with...");

            return root;
        }
    }

    private sealed class Second : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var root = new Tree("■ [yellow]Terminal[/]\n│");
            root.AddNode("Originally meant a TTY [italic](teletypewriter)[/]\n");
            root.AddNode("Nowadays, we use it about [green]software that displays text output[/]");

            return root;
        }
    }

    private sealed class Third : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var root = new Tree("■ [yellow]Shell[/]\n│");
            root.AddNode("An interface running [italic]\"on top\"[/] of the terminal, executing commands\n");
            root.AddNode("[gray]Examples:[/] [blue]bash[/], [blue]zsh[/], [blue]PowerShell[/], [blue]pwsh[/], [blue]cmd[/]");

            return root;
        }
    }

    private sealed class Fourth : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var root = new Tree("■ [yellow]CLI[/] / [yellow]Command-line Interface[/]\n│");
            root.AddNode("An application that accepts text input from the command line\n");

            return root;
        }
    }

    private sealed class Fifth : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var root = new Tree("■ [yellow]CLI[/] / [yellow]Command-line Interface[/]\n│");
            root.AddNode("An application that accepts text input from the command line\n");
            root.AddNode("[gray]Example:[/] [blue]git commit -m [green]'Lol'[/][/]");

            return root;
        }
    }

    private sealed class Sixth : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var root = new Tree("■ [yellow]CLI[/] / [yellow]Command-line Interface[/]\n│");
            root.AddNode("An application that accepts text input from the command line\n");
            root.AddNode("[gray]Example:[/] [yellow]git[/] [grey37]commit -m 'Lol'[/]\n         [yellow]^^^[/] [yellow]Executable[/]");

            return root;
        }
    }

    private sealed class Seventh : SlideStep
    {
        public override IRenderable Render(IRenderable? previous)
        {
            var root = new Tree("■ [yellow]CLI[/] / [yellow]Command-line Interface[/]\n│");
            root.AddNode("An application that accepts text input from the command line\n");
            root.AddNode("[gray]Example:[/] [grey37]git[/] [yellow]commit -m 'Lol'[/]\n             [yellow]^^^^^^^^^^^^^^^[/] [yellow]Text[/]");

            return root;
        }
    }
}
