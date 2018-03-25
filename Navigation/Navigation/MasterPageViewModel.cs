using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Navigation
{
    public class MasterPageViewModel : BaseViewModel
    {
        public INavigation Navigation;
        public List<MenuItem> MenuItems { get; set; }

        private MenuItem _selectedItem;
        public MenuItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                NavigateToNextPage(_selectedItem.Id, value.Id); // bierzemy id biezacej strony oraz wybranej strony
                _selectedItem = value;
                RaisePropertyChanged();
            }
        }
        public MasterPageViewModel()
        {
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Mapka", 0),
                new MenuItem("About", 1),
                new MenuItem("Samouczek", 2)
            };
            _selectedItem = MenuItems[0]; // trzeba tez ustawic w zmiennej prywatnej, zeby nie wywalilo sie przy pierwszym wywolaniu
            SelectedItem = MenuItems[0];  // ustawiamy zaznaczony element na pierwszy
        }

        private void NavigateToNextPage(int currentPage, int destinationPage) //metoda, ktora zmienia widoki
        {
            if (currentPage != destinationPage) //jezeli wybrana strona jest rozna od biezacej
            {
                var mdp = (MasterDetailPage)Application.Current.MainPage; // biezemy obiekt MasterDetailPage, dzieki czemu mozemy 
                switch (destinationPage)                                  // mu ustawiac podstrone (Detail)
                {
                    case 0:
                        mdp.Detail = new NavigationPage(new MainPage()); // nawigacja
                        mdp.IsPresented = false;
                        break;
                    case 1:
                        //mdp.Detail = new NavigationPage(new AboutPage()); // TODO
                        mdp.IsPresented = false;
                        break;
                    case 2:
                        mdp.Detail = new NavigationPage(new TutorialPage());
                        mdp.IsPresented = false;
                        break;
                }
            }
        }
    }

    public class MenuItem //obiekt, ktory ulatwia pokazywanie obiektow w liscie i nawigacje
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public MenuItem(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
