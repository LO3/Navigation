using System;
using Xamarin.Forms;

namespace Navigation
{
    public class Classroom
    {
        public string Name { get; set; }
        public Rectangle Region { get; set; }

        public Classroom(string name, Rectangle rectangle)
        {
            Name = name;
            Region = rectangle;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
