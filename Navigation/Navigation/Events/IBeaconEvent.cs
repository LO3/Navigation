using System;
using Xamarin.Forms;

namespace IBeaconLIc.Events
{
    public class IBeaconEvent : EventArgs
    {
        public string distanceDescription { get; set; }
        public string distance { get; set; }
        public string beaconsCount { get; set; }
        public Color backgroundColor { get; set; }
        public int? Minor { get; set; }
        public int? Major { get; set; }

        public IBeaconEvent(string distanceDescription, string distance, string beaconsCount, Color backgroundColor, int? major, int? minor)
        {
            this.distanceDescription = distanceDescription;
            this.distance = distance;
            this.beaconsCount = beaconsCount;
            this.backgroundColor = backgroundColor;
            Minor = minor;
            Major = major;
        }
    }
}
