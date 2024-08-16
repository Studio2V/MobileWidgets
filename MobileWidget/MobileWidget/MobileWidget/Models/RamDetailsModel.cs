using MobileWidget.Viewmodel;

namespace MobileWidget.Models
{
    public class RamDetailsModel : BaseViewModel
    {
        private string ramCapacity;

        private string ramUsed;

        private string lowMemort;
        
        private string percentageUsed;

        public string RamCapacity 
        {
            get => ramCapacity;
            set 
            {
                ramCapacity = value;
                NotifyPropertyChanged();
            }
        }

        public string RamUsed 
        {
            get => ramUsed;
            set
            {
                ramUsed = value;
                NotifyPropertyChanged();
            }
        }

        public string RamLow 
        {
            get => lowMemort;
            set
            {
                lowMemort = value;
                NotifyPropertyChanged();
            }
        }

        public string PercentageUsed
        {
            get => percentageUsed;
            set
            {
                percentageUsed = value;
                NotifyPropertyChanged();
            }
        }
    }
}
