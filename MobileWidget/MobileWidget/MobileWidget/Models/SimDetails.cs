using MobileWidget.Viewmodel;

namespace MobileWidget.Models
{
    public class SimDetails : BaseViewModel
    {
        string simStrength;

        public string SimStrength
        {
            get => simStrength;
            set
            {
                simStrength = value;
                NotifyPropertyChanged();
            }
        }
    }
}
