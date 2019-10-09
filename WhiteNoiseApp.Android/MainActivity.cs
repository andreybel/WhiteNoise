using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;

namespace WhiteNoiseApp.Droid
{
    [Activity(Label = "WhiteNoiseApp", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Forms.SetFlags("FastRenderers_Experimental");
            Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Plugin.Iconize.Iconize.Init(Resource.Id.toolbar, Resource.Id.sliding_tabs);
            LoadApplication(new App(new AndroidInitializer()));
            System.Diagnostics.Debug.WriteLine("Android launch time");
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}

