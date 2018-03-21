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

        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = e.Item.ToString();
            if (item != null)
            {
                ClassroomList.SelectedItem = false;
                MessagingCenter.Send<MainPage, Classroom> //Messenger wysyla wiadomosc, pod ktora sie podepniemy w ViewModelu
                    (this, "SelectedClassroom", (Classroom)e.Item); //wysyla caly obiekt, ktory kliknelismy na liscie w tym wypadku obiekt klasy Classroom

            }
        }
	}
}
