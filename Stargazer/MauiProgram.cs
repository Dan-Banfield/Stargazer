using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace Stargazer
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SFProDisplay-Medium", "SFProDisplayMedium");
                    fonts.AddFont("SFProDisplay-Regular", "SFProDisplayRegular");
                })
                .ConfigureLifecycleEvents(events =>
                {
#if ANDROID
                    events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeNavigationBarTranslucent(activity)));

                    static void MakeNavigationBarTranslucent(Android.App.Activity activity)
                    {
                        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                        {
                            activity.Window.AddFlags(Android.Views.WindowManagerFlags.LayoutNoLimits);
                            activity.Window.AddFlags(Android.Views.WindowManagerFlags.TranslucentNavigation);
                            activity.Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.Immersive;
                        }
                    }
#endif
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}