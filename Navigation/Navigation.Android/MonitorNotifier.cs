using System;
using RadiusNetworks.IBeaconAndroid;

namespace Navigation.Droid
{
    public class MonitorEventArgs : EventArgs
    {
        public Region Region { get; set; }

        public int State { get; set; }
    }

    public class MonitorNotifier : Java.Lang.Object, IMonitorNotifier
    {
        public event EventHandler<MonitorEventArgs> DetermineStateForRegionComplete;
        public event EventHandler<MonitorEventArgs> EnterRegionComplete;
        public event EventHandler<MonitorEventArgs> ExitRegionComplete;

        public void DidDetermineStateForRegion(int p0, Region p1)
        {
            OnDetermineStateForRegionComplete();
        }

        public void DidEnterRegion(Region regionEntered)
        {
            OnEnterRegionComplete(regionEntered);
        }

        public void DidExitRegion(Region regionEntered)
        {
            OnExitRegionComplete(regionEntered);
        }

        void OnDetermineStateForRegionComplete()
        {
            if (DetermineStateForRegionComplete != null)
            {
                DetermineStateForRegionComplete(this, new MonitorEventArgs());
            }
        }

        void OnEnterRegionComplete(Region regionEntered)
        {
            if (EnterRegionComplete != null)
            {
                MonitorEventArgs monitorEvent = new MonitorEventArgs();
                monitorEvent.Region = regionEntered;
                EnterRegionComplete(this, monitorEvent);
            }
        }

        void OnExitRegionComplete(Region regionEntered)
        {
            if (ExitRegionComplete != null)
            {
                MonitorEventArgs monitorEvent = new MonitorEventArgs();
                monitorEvent.Region = regionEntered;
                EnterRegionComplete(this, monitorEvent);
            }
        }
    }
}
