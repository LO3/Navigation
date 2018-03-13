using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation
{
	public partial class MainPage : ContentPage
	{
        void Handle_Focused(object sender, FocusEventArgs e)
        {
            MessagingCenter.Send<MainPage, bool>(this, "Entry", true);
        }

		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainPageViewModel();
		}
	}
}
