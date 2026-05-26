using AppShoppingCenter.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Platform;

namespace AppShoppingCenter;

public partial class App : Application
{
    public App()
    {
        CustomHandler();

        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    private void CustomHandler()
    {
        UserAppTheme = AppTheme.Light;

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(
            "EntryBorderless",
            (handler, view) =>
            {
                if (view is not Entry entry)
                    return;

#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__

                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        );
    }
}
