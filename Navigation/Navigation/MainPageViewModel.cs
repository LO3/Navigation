using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using IBeaconLIc.Events;
using IBeaconLIc.Interfaces;
using Navigation.Models;
using Xamarin.Forms;
using static IBeaconLIc.Events.IBeaconEvent;

namespace Navigation
{
    class MainPageViewModel : BaseViewModel
    {
        private string _classroom;
        public string EntryClassroom
        {
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


        public ICommand DismissListCommand { get; set; }
        private void DismissList()
        {
            IsListVisible = false;
        }

        public MainPageViewModel()
        {
            _isListVisible = false;
            DismissListCommand = new Command(DismissList);

            MessagingCenter.Subscribe<MainPage, bool>(this, "Entry", (sender, arg) =>
            {
                IsListVisible = arg;
                FilteredClassroomList = _classroomList;
            });



            var iBeaconService = DependencyService.Get<IiBeaconService>();
            iBeaconService.OnBeaconDataChanged += new IBeaconHandler(Notified);
            iBeaconService.Initialize();

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

        private Rectangle _pikachuPosition;
        public Rectangle PikachuPosition
        {
            get
            {
                return _pikachuPosition;
            }

            set
            {
                _pikachuPosition = value;
                RaisePropertyChanged();
            }
        }

        bool _isPikachuVisible = false;
        public bool IsPikachuVisible
        {
            get
            {
                return _isPikachuVisible;
            }
            set
            {
                _isPikachuVisible = value;
                RaisePropertyChanged();
            }
        }


        public void Notified(object source, IBeaconEvent e)
        {
            var beacon = Beacons.BeaconList.Where(b => b.Major == e.Major && b.Minor == e.Minor).FirstOrDefault();

            if (beacon != null)
            {  
                if(e.distanceDescription == "You did it")
                {
                    PikachuPosition = beacon.Region;
                    IsPikachuVisible = true;
                }
                else
                {
                    IsPikachuVisible = false;
                }
               
            }
        }
    }
}
