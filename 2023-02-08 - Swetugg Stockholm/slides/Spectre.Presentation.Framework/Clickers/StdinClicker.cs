using System;

namespace Spectre.Presentation.Framework;

public sealed class StdinClicker : IClicker
{
    public bool HasActivity()
    {
        return System.Console.KeyAvailable;
    }

    public ClickActivity WaitForActivity()
    {
        while (true)
        {
            var key = System.Console.ReadKey(true);
            if (key.Key == ConsoleKey.LeftArrow)
            {
                return ClickActivity.Previous;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                return ClickActivity.Next;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                return ClickActivity.Exit;
            }
        }
    }
}
