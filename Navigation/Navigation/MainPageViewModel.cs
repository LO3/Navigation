using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Navigation
{
    class MainPageViewModel : BaseViewModel
    {
        private string _classroom;
        public string Classroom {
            get
            {
                return _classroom;
            }
            set
            {
                _classroom = value;
                FilteredClassroomList = _classroomList.Where(e => e.Contains(_classroom)).ToList();
                RaisePropertyChanged();
            }
        }

        private List<string> _filteredClassroomList = _classroomList;
        public List<string> FilteredClassroomList
        {
            get
            {
                return _filteredClassroomList;
            }
            set
            {
                _filteredClassroomList = value;
                RaisePropertyChanged();

            }
        }

        private bool _isListVisible;
        public bool IsListVisible
        {
            get
            {
                return _isListVisible;
            }
            set 
            {
                _isListVisible = value;
                RaisePropertyChanged();
            }
        }
        public ICommand DismissListCommand { get; set; }
        private void DismissList()
        {
            IsListVisible = false;
        }

        public MainPageViewModel()
        {
            IsListVisible = false;
            DismissListCommand = new Command(DismissList);
            MessagingCenter.Subscribe<MainPage, bool>(this, "Entry", (sender, arg) =>
            {
                IsListVisible = arg;
                FilteredClassroomList = _classroomList;
            });
        }

        private static List<string> _classroomList = new List<string>
        {
            "sala1",
            "sala2",
            "sala3",
            "sala4",
            "sekretariat",
            "kantor woźnego"
        };
    }
}
