using System;
using CoreLocation;
using Navigation.Interfaces;
using Notification.Events;

namespace Navigation.iOS.Services
{
    public class IBeaconService : IiBeaconService
    {
        public event IBeaconEvent.IBeaconHandler OnBeaconDataChanged;

        IBeaconEvent _beaconEventArgs;


        public void Initialize()
        {
            _beaconEventArgs = new IBeaconEvent();

            AppDelegate.LocationManger.DidDetermineState += (s, e) =>
            {
                if (e.State == CLRegionState.Inside)
                {
                    _beaconEventArgs.Enter = true;
                    _beaconEventArgs.RegionId = e.Region.Identifier;
                    OnNotify(_beaconEventArgs);

                }
            };

            AppDelegate.LocationManger.RegionEntered += (s, e) =>
            {
                _beaconEventArgs.Enter = true;
                _beaconEventArgs.RegionId = e.Region.Identifier;
                OnNotify(_beaconEventArgs);
            };

            AppDelegate.LocationManger.RegionLeft += (s, e) =>
            {
                _beaconEventArgs.Enter = false;
                _beaconEventArgs.RegionId = e.Region.Identifier;
                OnNotify(_beaconEventArgs);
            };


            AppDelegate.LocationManger.RequestState(AppDelegate.BeaconRegion);

        }


        void OnNotify(IBeaconEvent eventArgs)
        {
            OnBeaconDataChanged(this, eventArgs);
        }
    }
}
