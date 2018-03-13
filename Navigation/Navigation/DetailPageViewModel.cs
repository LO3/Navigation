using System;
namespace Navigation
{
    public class DetailPageViewModel : BaseViewModel
    {
        private string _label;
        public string ClassroomName
        {
            get => _label;
            set
            {
                _label = value;
                RaisePropertyChanged();
            }
        }
        public DetailPageViewModel(string label)
        {
            ClassroomName = label;
        }
    }
}
