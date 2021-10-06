using Spectre.Console;
using Spectre.Console.Rendering;

namespace Slides
{
    public abstract class Slide
    {
        public SlideStep[] Steps { get; }
        public virtual string Title { get; } = " ";
        public virtual bool ShowHeader { get; } = true;
        public virtual Padding? Padding { get; } = null;

        public Slide(params SlideStep[] steps)
        {
            Steps = steps;
        }
    }

    public abstract class SlideStep
    {
        protected IRenderable GetBullet(params string[] bullets)
        {
            var grid = new Grid().AddColumns(2);

            foreach(var bullet in bullets)
            {
                grid.AddRow("[yellow]◼[/]", bullet);
            }

            return grid;
        }

        public abstract IRenderable GetRenderable(IRenderable previous);
    }
}
