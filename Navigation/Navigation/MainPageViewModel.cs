using System;
using System.Collections.Generic;
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
                RaisePropertyChanged();
            }
        }


        private List<string> _classroomList = new List<string>
        {
            "sala1",
            "sala2",
            "sala3",
            "sala4",
            "sekretariat"
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
                RaisePropertyChanged();

            }
        }
    }
}
