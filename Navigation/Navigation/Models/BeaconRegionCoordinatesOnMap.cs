using System;
namespace Navigation.Models
{
    public class BeaconRegionCoordinatesOnMap
    {
        public string Name;
        public double X;
        public double Y;
        public double Width;
        public double Height;

        public BeaconRegionCoordinatesOnMap(string name, double x, double y, double width, double height)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}
