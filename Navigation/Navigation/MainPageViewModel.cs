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
                FilteredClassroomList = _classroomList.Where(e => e.Name.ToLower().Contains(_classroom.ToLower())).ToList();
                RaisePropertyChanged();
            }
        }


        private List<Classroom> _filteredClassroomList;
        public List<Classroom> FilteredClassroomList
        {
            get
            {
                return _filteredClassroomList;
            }
            set
            {
                _filteredClassroomList = value.ToList();
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

        private bool _isDestinationVisible = false;
        public bool IsDestinationVisible
        {
            get => _isDestinationVisible;
            set { _isDestinationVisible = value; RaisePropertyChanged(); }
        }

        private Rectangle _destinationPosition;
        public Rectangle DestinationPosition
        {
            get => _destinationPosition;
            set { _destinationPosition = value; RaisePropertyChanged(); }
        }

        private string _selectedClassroom;
        public string SelectedClassroom
        {
            get => _selectedClassroom;
            set { _selectedClassroom = value; RaisePropertyChanged(); }
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

            MessagingCenter.Subscribe<MainPage, Classroom>(this, "SelectedClassroom", (sender, arg) =>
            {
                IsListVisible = false;          //Odbieramy wiadomosc z Handle_ItemTapped
                IsDestinationVisible = true;    //Ustawiamy widocznosc pinezki na true
                DestinationPosition = arg.Region; //Ustawiamy pozycje na jakiej ma sie wyswietlic pinezka
                SelectedClassroom = arg.Name; //Ustawiamy Placeholder w Entry na nazwe wybranego przez uzytkownika pokoju

            });


            var IBeaconService = DependencyService.Get<IiBeaconService>();
            IBeaconService.OnBeaconDataChanged += new IBeaconHandler(Notified);
            IBeaconService.Initialize();
        }

        private List<Classroom> _classroomList = new List<Classroom>
        {
            new Classroom("Kuchnia", BeaconsRegion.KitchenBeacon),
            new Classroom("MobiSmerfy", BeaconsRegion.MobiSmerfsBeacon),
            new Classroom("Księgowość", BeaconsRegion.OfficeBeacon),
            new Classroom("Mobilki", BeaconsRegion.MobileBeacon),
            new Classroom("Admini", BeaconsRegion.AdminsBeacon),
            new Classroom("PlayRoom", BeaconsRegion.PlayRoomBeacon),
            new Classroom("MeetingRoom", BeaconsRegion.MeetingRoomBeacon),
            new Classroom("InnyPokoj", BeaconsRegion.StrangeRoomBeacon)
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
