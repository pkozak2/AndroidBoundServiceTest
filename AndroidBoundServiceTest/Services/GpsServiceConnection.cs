using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AndroidBoundServiceTest.Services
{
    public class GpsServiceConnection : Java.Lang.Object, IServiceConnection
    {
        static readonly string TAG = typeof(GpsServiceConnection).FullName;

        BaseActivity baseActivity;

		public GpsServiceConnection(BaseActivity activity)
		{
			baseActivity = activity;
		}


		public void OnServiceConnected(ComponentName name, IBinder service)
		{
			Log.Debug(TAG, $"OnServiceConnected {name.ClassName}");
			if (service != null)
			{
				baseActivity.GpsServiceBinder = service as GPSServiceBinder;
				baseActivity.GpsServiceBound = true;
				baseActivity.RunOnUiThread(() =>
				{
					baseActivity.GpsServiceConnected();
				});
			}

		}

		public void OnServiceDisconnected(ComponentName name)
		{
			Log.Debug(TAG, $"OnServiceDisconnected {name.ClassName}");
			baseActivity.GpsServiceBinder = null;
			baseActivity.GpsServiceBound = false;
		}
	}

}