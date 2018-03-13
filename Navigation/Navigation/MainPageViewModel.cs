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
        public string EntryClassroom {
            get
            {
                return _classroom;
            }
            set
            {
                _classroom = value;
                SetAndShowClassroomList(_classroom);
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

            MessagingCenter.Subscribe<MainPage, bool>(this, "Entry", (sender, arg) => {
                IsListVisible = arg;
                FilteredClassroomList = _classroomList;
            });  
        }

		private void SetAndShowClassroomList(string classroom)
		{
            if (classroom.Length == 0)
                FilteredClassroomList = _classroomList;
            else
            {
                FilteredClassroomList = _classroomList.Where(e => e.Contains(FirstLetterUppercase(_classroom))).ToList();
                IsListVisible = true;
            }
		}

        private string FirstLetterUppercase(string word)
        {
            string res = word[0].ToString().ToUpper();
            for (int i = 1; i < word.Length; i++)
            {
                res += word[i].ToString().ToLower();
            }

            return res;
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
    }
}
