using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace WhiteNoiseApp.Droid
{
    [Activity(Theme = "@style/MainTheme.Splash", MainLauncher = true, NoHistory = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : AppCompatActivity
    {
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(Startup);
            startupWork.Start();
        }

        // Prevent the back button from canceling the startup process
        public override void OnBackPressed() { }

        // Simulates background work that happens behind the splash screen
        void Startup()
        {
            var intent = new Intent(Application.Context, typeof(MainActivity));
            if (Intent.Extras != null)
                intent.PutExtras(Intent.Extras);
            StartActivity(intent);
        }
    }
}
