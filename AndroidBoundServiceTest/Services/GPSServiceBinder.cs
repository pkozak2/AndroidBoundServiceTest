using Android.OS;

namespace AndroidBoundServiceTest.Services
{
    public class GPSServiceBinder : Binder
    {
        readonly GPSService service;
        public GPSServiceBinder(GPSService service)
        {
            this.service = service;
        }

        public GPSService GetGPSService()
        {
            return service;
        }
    }
}