using System;

using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidBoundServiceTest.Services;

namespace AndroidBoundServiceTest
{
    //BASED ON: https://github.com/xamarin/mobile-samples/tree/master/BackgroundLocationDemo/location.Android
    [Activity(Label = "LocationDroid", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.ScreenLayout)]
    public class MainActivity : BaseActivity
    {
        static readonly string TAG = "MainActivity";
        //Lifecycle stages
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);

          
        }

        protected override void OnStart()
        {

           
            base.OnStart();
            StartServices();
            
        }

        protected override void OnResume()
        {
            base.OnResume();
            BindToGpsService();
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnbindFromGpsService();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            StopServices();


        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
        }



        //void DoBindService()
        //{
        //    Intent serviceToStart = new Intent(this, typeof(MusicPlayerService));
        //    BindService(serviceToStart, serviceConnection, Bind.AutoCreate);


        //}

        //void DoUnBindService()
        //{
        //    UnbindService(serviceConnection);
        //}
    }
}