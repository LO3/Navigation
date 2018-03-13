using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Navigation
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(string classroomName)
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout()
            {
                BackgroundColor = Color.Green
            };



            StackLayout stackLayout = new StackLayout
            {
                Spacing = 15,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Red

            };

            Label classroomNameLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                Text = classroomName
            };

            Image image = new Image
            {
                Source = "jit.png",
                Aspect = Aspect.Fill
            };

            stackLayout.Children.Add(classroomNameLabel);


            AbsoluteLayout.SetLayoutBounds(image, new Rectangle(1, 1, 1, 1));
            AbsoluteLayout.SetLayoutFlags(image, AbsoluteLayoutFlags.All);

            AbsoluteLayout.SetLayoutBounds(stackLayout, new Rectangle(0.5, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(stackLayout, AbsoluteLayoutFlags.All);


            absoluteLayout.Children.Add(image);
            absoluteLayout.Children.Add(stackLayout);

            this.Content = absoluteLayout;


        }
    }
}
