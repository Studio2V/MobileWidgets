using MobileWidget.Viewmodel;

namespace MobileWidget.Models
{
    public class BatteryDetailsModel : BaseViewModel
    {
        private string state;
        private string powersource;
        private string energysaverstatus;
        private string chargelevel;

        public string State { get => state; set { state = value; NotifyPropertyChanged(); } }
        public string Powersource { get => powersource; set { powersource = value; NotifyPropertyChanged(); } }
        public string Energysaverstatus { get => energysaverstatus; set { energysaverstatus = value; NotifyPropertyChanged(); } }
        public string Chargelevel { get => chargelevel; set { chargelevel = value; NotifyPropertyChanged(); } }
    }
}
