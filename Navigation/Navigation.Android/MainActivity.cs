using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using RadiusNetworks.IBeaconAndroid;
using Navigation.Droid;
using Xamarin.Forms;
using Notification.Events;
using Navigation.Interfaces;
using static Notification.Events.IBeaconEvent;


namespace Navigation.Droid
{
    [Activity(Label = "Navigation", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IBeaconConsumer
    {
        public static IBeaconManager beaconMgr;
        public static MonitorNotifier monitorNotifier;
        public static RangeNotifier rangeNotifier;
        public static Region monitoringRegion;
        public static Region rangingRegion;
        public static IBeaconEvent _beaconEventArgs;


        public MainActivity()
        {
            beaconMgr = IBeaconManager.GetInstanceForApplication(this);

            monitorNotifier = new MonitorNotifier();

            monitoringRegion = new Region("test", "B9407F30-F5F8-466E-AFF9-25556B57FE6D", (Java.Lang.Integer)3605, (Java.Lang.Integer)17538);
           
        }

       // public event IBeaconHandler OnBeaconDataChanged;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            beaconMgr.Bind(this);

            LoadApplication(new App());
        }

        public void OnIBeaconServiceConnect()
        {
            
            beaconMgr.StartMonitoringBeaconsInRegion(monitoringRegion);
            beaconMgr.SetMonitorNotifier(monitorNotifier);

        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            //monitorNotifier.EnterRegionComplete -= EnteredRegion;
            //monitorNotifier.ExitRegionComplete -= ExitedRegion;

            beaconMgr.StopMonitoringBeaconsInRegion(monitoringRegion);
            beaconMgr.StopRangingBeaconsInRegion(rangingRegion);
            beaconMgr.UnBind(this);
        }

        //public void EnteredRegion(object sender, MonitorEventArgs e)
        //{
        //    if (e.Region != null)
        //    {
        //        _beaconEventArgs.Enter = true;
        //        _beaconEventArgs.RegionId = e.Region.UniqueId;
        //       // OnNotify(_beaconEventArgs);
        //    }
         
        //}

        //public void ExitedRegion(object sender, MonitorEventArgs e)
        //{
        //    _beaconEventArgs.Enter = false;
        //    _beaconEventArgs.RegionId = e.Region.UniqueId;
        //    //OnNotify(_beaconEventArgs);
        //}

        //public void StartMonitoring()
        //{
        //    _beaconEventArgs = new IBeaconEvent();
        //    monitorNotifier.EnterRegionComplete += EnteredRegion;
        //    monitorNotifier.ExitRegionComplete += ExitedRegion;
        //}

    }
}

