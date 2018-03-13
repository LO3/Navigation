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
                //System.Diagnostics.Debug.WriteLine("Beka: " + item);
                await Navigation.PushAsync(new DetailPage(item));
            }
        }
	}
}
