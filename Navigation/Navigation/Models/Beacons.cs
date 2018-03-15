using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Navigation.Models
{
    public static class Beacons
    {
        public static readonly List<Beacon> BeaconList = new List<Beacon>
        {
            new Beacon("Paxer", 53698, 5908, BeaconsRegions.Sala2Beacon),
            new Beacon("Zimno", 3605, 17538, BeaconsRegions.Sala1Beacon)
        };
    }

    public class Beacon
    {
        public string Name { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public Rectangle Region { get; set; }

        public Beacon(string name, int major, int minor, Rectangle region)
        {
            Name = name;
            Major = major;
            Minor = minor;
            Region = region;
        }
    }
}
