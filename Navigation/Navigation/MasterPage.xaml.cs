using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Navigation
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
            var vm = new MasterPageViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}
