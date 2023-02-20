﻿using System.ComponentModel.Composition;

namespace DevToys.UnitTests.Mocks.Tools;

[Export(typeof(GuiToolGroup))]
[Name("MockGroup")]
internal sealed class MockGuiToolGroup : GuiToolGroup
{
    [ImportingConstructor]
    internal MockGuiToolGroup()
    {
        IconFontName = "Fluent System-Regular";
        IconGlyph = "\u0108";
        DisplayTitle = "Group title";
        AccessibleName = "Group title";
    }
}
