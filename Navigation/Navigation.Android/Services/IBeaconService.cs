using System;
using Navigation.Droid.Services;
using Navigation.Interfaces;
using Notification.Events;
using Xamarin.Forms;
using static Notification.Events.IBeaconEvent;

[assembly: Dependency(typeof(IBeaconService))]
namespace Navigation.Droid.Services 
{
    public class IBeaconService : IiBeaconService
    {
        public event IBeaconHandler OnBeaconDataChanged;
        IBeaconEvent _beaconEventArgs;

        public void Initialize()
        {
            MainActivity.monitorNotifier.EnterRegionComplete += EnteredRegion;
            MainActivity.monitorNotifier.ExitRegionComplete += ExitedRegion;
        }

        public void EnteredRegion(object sender, MonitorEventArgs e)
        {
            if (e.Region != null)
            {
                _beaconEventArgs = new IBeaconEvent();
                _beaconEventArgs.Enter = true;
                _beaconEventArgs.RegionId = e.Region.UniqueId;
                OnNotify(_beaconEventArgs);
            }
        }

        void ExitedRegion(object sender, MonitorEventArgs e)
        {
            if (e.Region != null)
            {
                _beaconEventArgs = new IBeaconEvent();
                _beaconEventArgs.Enter = false;
                _beaconEventArgs.RegionId = e.Region.UniqueId;
                OnNotify(_beaconEventArgs);
            }
        }


        public void OnNotify(IBeaconEvent eventArgs)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                OnBeaconDataChanged(this, eventArgs);
            });
        }
    }
}
