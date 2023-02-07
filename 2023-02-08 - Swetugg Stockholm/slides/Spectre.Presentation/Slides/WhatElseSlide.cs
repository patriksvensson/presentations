using System.Collections.Generic;
using Spectre.Console;
using Spectre.Console.Rendering;
using Spectre.Presentation.Framework;

namespace Spectre.Presentation;

public sealed class WhatElseSlide : BulletSlide
{
    public override string Title { get; } = "What else can it do?";

    protected override IEnumerable<IRenderable> GetRenderables()
    {
        var items = new List<string>
        {
            "Tables", "Trees", "Canvas rendering", "Image renderering", "Pretty exception rendering",
            "Live display", "Progess display", "Status display",
            "Text prompts", "Selection prompts", "Multi-selection prompts",
            "Bar charts", "Breakdown charts", "Horizontal lines", "Calendars",
            "Figlet text renderering", "Command Line Parsing", "Panels", "Aligning", "Calendars",
            "Row Layouts", "Column Layouts", "Rich markup", "Colors", "Much more... 😅",
        };

        yield return new Markup(string.Join(", ", items));
    }
}
