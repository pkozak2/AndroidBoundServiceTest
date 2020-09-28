using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using AndroidBoundServiceTest.Services;

namespace AndroidBoundServiceTest
{
    public class BaseActivity : AppCompatActivity
    {
        public GpsServiceConnection ServiceConnection;
        public GPSServiceBinder GpsServiceBinder { get; internal set; }
        public bool GpsServiceBound { get; internal set; }

        public bool GpsServiceStarted = false;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (savedInstanceState != null)
            {
                GpsServiceStarted = savedInstanceState.GetBoolean(Constants.SERVICE_STARTED_KEY, false);
            }
        }

        protected override void OnNewIntent(Intent intent)
        {
            if (intent == null)
            {
                return;
            }

            var bundle = intent.Extras;
            if (bundle != null)
            {
                if (bundle.ContainsKey(Constants.SERVICE_STARTED_KEY))
                {
                    GpsServiceStarted = true;
                }
            }
        }

        public void GpsServiceConnected()
        {
            //InitLibraryListeners();
        }

        protected void BindToGpsService()
        {
            GpsServiceBound = false;
            var intent = new Intent(this, typeof(GPSService));
            try
            {
                ServiceConnection = new GpsServiceConnection(this);
                BindService(intent, ServiceConnection, Bind.AutoCreate);
            }
            catch (System.Exception ex)
            {
                Toast.MakeText(this, "Oh oh: " + ex.Message, ToastLength.Short).Show();
            }
        }

        protected void UnbindFromGpsService()
        {
            //DestroyLibraryListeners();

            if (ServiceConnection != null &&
                GpsServiceBinder != null &&
                GpsServiceBinder.IsBinderAlive)
            {
                try
                {
                    UnbindService(ServiceConnection);
                }
                catch { }
            }
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutBoolean(Constants.SERVICE_STARTED_KEY, GpsServiceStarted);
            base.OnSaveInstanceState(outState);
        }


        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        protected void StartServices()
        {
            if (!GpsServiceStarted)
            {
                Intent startServiceIntent = new Intent(this, typeof(GPSService));
                startServiceIntent.SetAction(Constants.ACTION_START_SERVICE);

                StartService(startServiceIntent);
            }
        }

        protected void StopServices()
        {
            Intent stopServiceIntent = new Intent(this, typeof(GPSService));
            stopServiceIntent.SetAction(Constants.ACTION_STOP_SERVICE);
            StopService(stopServiceIntent);
        }
    }
}