﻿using DevToys.Api;
using Microsoft.Extensions.Logging;

namespace DevToys.Tools.Sample;

[Export(typeof(ICommandLineTool))]
[Name("Sample tool")]
[Author("John Doe")]
[CommandName(
    Name = "base64",
    Alias = "b64",
    ResourceManagerBaseName = "DevToys.Tools.Sample.Sample",
    DescriptionResourceName = nameof(Sample.CommandDescription))]
[TargetPlatform(Platform.Windows)] // Optional. Not putting any attribute means every platforms are supported.
[TargetPlatform(Platform.Linux)]
[TargetPlatform(Platform.MacCatalyst)]
internal sealed class SampleCommandLineTool : ICommandLineTool
{
    [CommandLineOption(
        Name = "file",
        Alias = "f",
        IsRequired = true,
        DescriptionResourceName = nameof(Sample.FileOptionDescription))]
    private FileInfo? File { get; set; }

    [CommandLineOption(
        Name = "utf8",
        DescriptionResourceName = nameof(Sample.Utf8OptionDescription))]
    private bool Utf8 { get; set; } = true; // Default value is true.

    public ValueTask<int> InvokeAsync(ILogger logger, CancellationToken cancellationToken)
    {
        Console.WriteLine("Dummy output.");
        return new ValueTask<int>(0);
    }
}

[Export(typeof(IGuiTool))]
[Name("Sample tool")]
[Author("John Doe")]
[ToolDisplayInformation(
    IconFontName = "Fluent System-Regular",
    IconGlyph = "\u0108",
    GroupName = "Encoders / Decoders",
    ResourceManagerAssemblyIdentifier = nameof(DevToysToolsResourceManagerAssemblyIdentifier),
    ResourceManagerBaseName = "DevToys.Tools.Sample.Sample",
    ShortDisplayTitleResourceName = nameof(Sample.CommandDescription),
    LongDisplayTitleResourceName = nameof(Sample.CommandDescription),
    DescriptionResourceName = nameof(Sample.CommandDescription),
    AccessibleNameResourceName = nameof(Sample.CommandDescription),
    SearchKeywordsResourceName = nameof(Sample.CommandDescription))]
[TargetPlatform(Platform.Windows)] // Optional. Not putting any attribute means every platforms are supported.
[TargetPlatform(Platform.Linux)]
[TargetPlatform(Platform.MacCatalyst)]
[TargetPlatform(Platform.WASM)]
internal sealed class SampleGuiTool : IGuiTool
{
    public UIElement View => throw new NotImplementedException();
}

[Export(typeof(GuiToolGroup))]
[Name("Encoders / Decoders")]
internal sealed class EncodersDecodersGroup : GuiToolGroup
{
    [ImportingConstructor]
    internal EncodersDecodersGroup()
    {
        IconFontName = "Fluent System-Regular";
        IconGlyph = "\u0108";
        DisplayTitle = Sample.CommandDescription;
        AccessibleName = Sample.CommandDescription;
    }
}
