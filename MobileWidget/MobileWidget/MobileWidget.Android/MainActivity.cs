using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net.Wifi;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using AndroidX.Core.App;
using MobileWidget.Droid.IntentRecievers;
using System;
using static Android.Icu.Text.IDNA;

namespace MobileWidget.Droid
{
    [Activity(Label = "MobileWidget", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        WifiIntentReceiver WifiIntentReceiver = new WifiIntentReceiver();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            //this.ActionBar.SetBackgroundDrawable(Android.Resource.Drawable.));
            // var tool = GetDrawable(Resource.Drawable.toolbarGradient);
            // this.ActionBar.SetCustomView(Resource.Id.toolbar);

            LoadApplication(new App());
        }
    
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (ActivityCompat.CheckSelfPermission(this, Manifest.Permission.AccessFineLocation)!=Android.Content.PM.Permission.Granted)
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.AccessFineLocation }, 1);
            }
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnStart()
        {
            base.OnStart();
           // registerRecievers();
        }

        protected override void OnStop()
        {
            base.OnStop();
           // unregisterReceivers();
        }

        private void registerRecievers()
        {
            IntentFilter inf = new IntentFilter(WifiManager.WifiStateChangedAction);
            RegisterReceiver(WifiIntentReceiver, inf);
        }

        private void unregisterReceivers()
        {
            UnregisterReceiver(WifiIntentReceiver);
        }

    }
}