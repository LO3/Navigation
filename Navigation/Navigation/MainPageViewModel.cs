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
        public List<string> _classrooms = new List<string>
        {

            "sala 1",
            "sala2",
            "sala3",
            "sala4",
            "sekretariat",

        };
        public List<string> Classrooms
        {
            get
            {
                return _classrooms;
            }
            set
            {
                _classrooms = value;
            }
        }
    }
}
