using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Headless;

namespace tests;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }
}