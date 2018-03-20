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
                NavigateToNextPage(_selectedItem.Id, value.Id);
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
            _selectedItem = MenuItems[0];
            SelectedItem = MenuItems[0];
        }

        private void NavigateToNextPage(int currentPage, int destinationPage)
        {
            if (currentPage != destinationPage)
            {
                var mdp = (MasterDetailPage)Application.Current.MainPage;
                switch (destinationPage)
                {
                    case 0:
                        mdp.Detail = new NavigationPage(new MainPage());
                        mdp.IsPresented = false;
                        break;
                    case 1:
                        //mdp.Detail = new NavigationPage(new AboutPage());
                        mdp.IsPresented = false;
                        break;
                    case 2:
                        //mdp.Detail = new NavigationPage(new SelfGuidedPage());
                        mdp.IsPresented = false;
                        break;
                }
            }
        }
    }

    public class MenuItem
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
