using MobileWidget.Viewmodel;

namespace MobileWidget.Models
{
    public class BluetoothDetailsModel : BaseViewModel
    {
        private string _bluetoothName;

        private string _bluetoothStatus;

        public string BluetoothStatus
        {
            get => _bluetoothStatus;
            set
            {
                _bluetoothStatus = value;
                NotifyPropertyChanged();
            }
        }

        public string BluetoothName
        {
            get => _bluetoothName;
            set
            {
                _bluetoothName = value;
                NotifyPropertyChanged();
            }
        }
    }
}
