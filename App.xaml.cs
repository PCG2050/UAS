using Microsoft.Maui.Platform;
#if __IOS__
using UIKit;
#endif

namespace UAS
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Custom handler for BorderlessEntry
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
                if (view is BorderlessEntry)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetPadding(0, 0, 0, 0);
#elif __IOS__
                    handler.PlatformView.BorderStyle = UITextBorderStyle.None;
#elif WINDOWS
                    handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#endif
                }
            });

            // Custom handler for BorderlessPicker
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(BorderlessPicker), (handler, view) =>
            {
                if (view is BorderlessPicker)
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
                    handler.PlatformView.Background = null;
#elif __IOS__
                    handler.PlatformView.BorderStyle = UITextBorderStyle.None;
#elif WINDOWS
                    handler.PlatformView.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
#endif
                }
            });

            MainPage = new AppShell();
        }
    }
}


