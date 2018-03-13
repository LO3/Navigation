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
        void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            MessagingCenter.Send(this, "Entry", true);
        }

		public MainPage()
		{
			InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem.ToString();
            if (item != null)
            {
                await Navigation.PushAsync(new DetailPage(item));
            }
        }
	}
}
