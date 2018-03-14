using System;
using System.Collections.Generic;

namespace Navigation.Models
{
    public static class Beacons
    {

        public static readonly List<Beacon> BeaconList = new List<Beacon>
            {   new Beacon("Pacio", 10222, 43772),
                new Beacon("Mareczek", 27666, 49087),
                new Beacon("Paxer", 53698, 5908),
                new Beacon("Zimno", 3605, 17538)
            };
    }

    public class Beacon
    {
        public string Name { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }

        public Beacon(string name, int major, int minor)
        {
            Name = name;
            Major = major;
            Minor = minor;
        }
    }
}
