using MobileWidget.Viewmodel;

namespace MobileWidget.Models
{
    public class ConnectivityDetailsModel : BaseViewModel
    {
        private string _connected;

        private string _profile;

        public string Connected
        {
            get => _connected;
            set
            {
                _connected = value;
                NotifyPropertyChanged();
            }
        }

        public string Profile
        {
            get => _profile;
            set
            {
                _profile = value;
                NotifyPropertyChanged();
            }
        }
    }
}
