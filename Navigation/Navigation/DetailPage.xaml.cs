using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Navigation
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(string classroomName)
        {
            InitializeComponent();
            BindingContext = new DetailPageViewModel(classroomName);
        }
    }
}