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
    }
}
