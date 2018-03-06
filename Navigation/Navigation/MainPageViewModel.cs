using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        private static List<string> _classroomList = new List<string>
        {
            "sala1",
            "sala2",
            "sala3",
            "sala4",
            "sekretariat",
            "kantor woźnego"
        };

        public List<string> ClassroomList
        {
            get
            {
                return _classroomList;
            }
            set
            {
                _classroomList = value;
            }
        }
    }
}
