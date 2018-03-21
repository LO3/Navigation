using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Navigation.Interfaces;
using Notification.Events;
using Xamarin.Forms;
using static Notification.Events.IBeaconEvent;

namespace Navigation
{
    class MainPageViewModel : BaseViewModel
    {
        private string _classroom;
        public string EntryClassroom {
            get
            {
                return _classroom;
            }
            set
            {
                _classroom = value;
                FilteredClassroomList = _classroomList.Where(e => e.ToLower().Contains(_classroom.ToLower())).ToList();
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


        public bool _isVisible = false;
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
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
            _isListVisible = false;
            DismissListCommand = new Command(DismissList);

            MessagingCenter.Subscribe<MainPage, bool>(this, "Entry", (sender, arg) => {
                IsListVisible = arg;                        //Messenger jest uzywany do wysylania informacji (wartosci) miedzy klasami
                FilteredClassroomList = _classroomList;     //w tym wypadku odbieramy(subskrybujemy) na wartosc typu bool zeby zamykac liste
            });

            var IBeaconService = DependencyService.Get<IiBeaconService>();
            IBeaconService.OnBeaconDataChanged += new IBeaconHandler(Notified);
            IBeaconService.Initialize();
        }

        private static List<string> _classroomList = new List<string>
        {
            "Sala1",
            "Sala2",
            "Sala3",
            "Sala4",
            "Sekretariat",
            "Kantor woźnego"
        };

        public void Notified(object source, IBeaconEvent e)
        {
            if(e.Enter == true)
            {
                IsVisible = true;
            }
            else
            {
                IsVisible = false;
            }
        }
    }
}
