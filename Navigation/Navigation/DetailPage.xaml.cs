using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Navigation
{
    public partial class DetailPage : ContentPage
    {
        public string Item { get; set; } = "";

        public DetailPage()
        {
            InitializeComponent();
            var vm = new DetailPageViewModel();
            vm.ClassroomName = Item;
            BindingContext = vm;
        }
    }
}