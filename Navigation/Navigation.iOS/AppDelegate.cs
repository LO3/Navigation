using System;
using System.Collections.Generic;
using System.Linq;
using CoreLocation;
using Foundation;
using UIKit;

namespace Navigation.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //


        public static CLLocationManager LocationManger;
        NSUuid beaconUUID;
        public static CLBeaconRegion BeaconRegion;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            LocationManger = new CLLocationManager();
            LocationManger.RequestAlwaysAuthorization();
            beaconUUID = new NSUuid("B9407F30-F5F8-466E-AFF9-25556B57FE6D");

            BeaconRegion = new CLBeaconRegion(beaconUUID, 3605, 17538, "Sala1");
            BeaconRegion.NotifyOnEntry = true;
            BeaconRegion.NotifyOnExit = true;
            BeaconRegion.NotifyEntryStateOnDisplay = true;

            LocationManger.StartMonitoring(BeaconRegion);

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
