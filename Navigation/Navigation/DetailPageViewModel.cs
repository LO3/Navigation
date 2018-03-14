using System;
namespace Navigation
{
    public class DetailPageViewModel : BaseViewModel
    {
        private string _classroomName;
        public string ClassroomName
        {
            get => _classroomName;
            set
            {
                _classroomName = value;
                RaisePropertyChanged();
            }
        }
        public DetailPageViewModel(string label)
        {
            ClassroomName = label;
        }
    }
}
