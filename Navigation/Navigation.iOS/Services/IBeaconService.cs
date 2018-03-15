using System;
using CoreLocation;
using Foundation;
using IBeaconLIc.Events;
using IBeaconLIc.Interfaces;
using IBeaconLIc.iOS.Services;
using Navigation.Models;
using Xamarin.Forms;
using static IBeaconLIc.Events.IBeaconEvent;

[assembly: Dependency(typeof(IBeaconService))]
namespace IBeaconLIc.iOS.Services
{
    public class IBeaconService : IiBeaconService
    {
        CLLocationManager locationManager;
        NSUuid beaconUUID;
        CLBeaconRegion beaconRegion;

        const ushort beaconMajor = 3605;
        const ushort beaconMinor = 17538;

        public event IBeaconHandler OnBeaconDataChanged;

        string beaconsCount;
        string distanceDescription;
        string distance;
        Color backgroundColor;

       

        public void Initialize()
        {
            locationManager = new CLLocationManager();
            locationManager.RequestWhenInUseAuthorization();

            beaconUUID = new NSUuid(BeaconCreds.UUID);
            beaconRegion = new CLBeaconRegion(beaconUUID, BeaconCreds.BEACON_ID);

            locationManager.DidRangeBeacons += (object sender, CLRegionBeaconsRangedEventArgs e) =>
            {
                if (e.Beacons == null || e.Beacons.Length == 0)
                    return;

                beaconsCount = e.Beacons.Length.ToString();

                int tempIndex = 0;

                for (int i = 1; i < e.Beacons.Length; i++)
                {
                    if (e.Beacons[i].Proximity < e.Beacons[tempIndex].Proximity)
                    {
                        tempIndex = i;
                    }
                }

                var beacon = e.Beacons[tempIndex];
                switch (beacon.Proximity)
                {
                    case CLProximity.Far:
                        backgroundColor = Color.Blue;
                        distanceDescription = "Getting closer";
                        break;
                    case CLProximity.Near:
                        backgroundColor = Color.Yellow;
                        distanceDescription = "Almost found it";
                        break;
                    case CLProximity.Immediate:
                        backgroundColor = Color.GreenYellow;
                        distanceDescription = "You did it";
                        break;
                    case CLProximity.Unknown:
                        backgroundColor = Color.White;
                        distanceDescription = "oh no";
                        return;
                }

                distance = beacon.Accuracy.ToString();
                OnNotify(new IBeaconEvent(distanceDescription, distance, beaconsCount, backgroundColor, 
                                          Int32.Parse(beacon.Major.ToString()), Int32.Parse(beacon.Minor.ToString())));
            };

            locationManager.StartRangingBeacons(beaconRegion);

        }


        void OnNotify(IBeaconEvent eventArgs)
        {
            OnBeaconDataChanged(this, eventArgs);
        }
           
    }
}
