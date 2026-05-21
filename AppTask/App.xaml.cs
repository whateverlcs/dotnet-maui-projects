using AppTask.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Platform;

namespace AppTask;

public partial class App : Application
{
    public App()
    {
        CustomHandler();

        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new StartPage()));
    }

    private void CustomHandler()
    {
        EntryNoBorder();
        DatePickerNoBorder();
    }

    private static void EntryNoBorder()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(
            "NoBorder",
            (handler, view) =>
            {
                if (view is not Entry entry)
                    return;

#if ANDROID
                //ANDROID
                handler.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST

                //iOS //MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS

                //WINDOWS
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            }
        );
    }

    private static void DatePickerNoBorder()
    {
        Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping(
            "NoBorder",
            (handler, view) =>
            {
                if (view is not DatePicker datePicker)
                    return;

#if ANDROID
                //ANDROID
                handler.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST

                //iOS //MACCATALYST
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS

                //WINDOWS
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            }
        );
    }
}
