using System;
using Xamarin.Forms;

namespace Notification.Events
{
    public class IBeaconEvent : EventArgs
    {
        public string RegionId { get; set; }
        public bool Enter { get; set; }


        public delegate void IBeaconHandler(object sender, IBeaconEvent e);
    }
}
