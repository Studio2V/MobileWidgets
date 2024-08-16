using MobileWidget.Common;
using MobileWidget.Models;
using MobileWidget.ServiceWrapper;
using MobileWidget.Views.ContentViews;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileWidget.Viewmodel
{
    public class HardwareDetailsViewmodel : BaseViewModel
    {
        private string versions;

        private BatteryDetailsModel batteryDetails;

        private RamDetailsModel _ramDetails;

        private RomDetailsModel _romDetailsModel;

        private ConnectivityDetailsModel _connectivityDetailsModel;

        private WifiDetailsModel _wifiDetailsModel;

        private SimDetails _simDetails;

        private BluetoothDetailsModel _bluetoothDetailsModel;

        private static HardwareDetailsViewmodel _instance;

        public static HardwareDetailsViewmodel Instance
        {
            get
            {
                _instance = _instance?? new HardwareDetailsViewmodel();
                return _instance;
            }
        }

        public string Versions
        {
            get => versions;
            set
            {
                versions = value;
                NotifyPropertyChanged();
            }
        }

        public BatteryDetailsModel BatteryDetails
        {
            get => batteryDetails;
            set
            {
                batteryDetails = value;
                NotifyPropertyChanged();
            }
        }

        public RamDetailsModel RamDetails 
        {
            get => _ramDetails;
            set
            {
                _ramDetails = value;
                NotifyPropertyChanged();
            }
        }

        public RomDetailsModel RomDetailsModel
        {
            get => _romDetailsModel;
            set
            {
                _romDetailsModel = value;
                NotifyPropertyChanged();
            }
        }

        public ConnectivityDetailsModel ConnectivityDetailsModel 
        {
            get => _connectivityDetailsModel;
            set
            {
                _connectivityDetailsModel = value;
            }
        }

        public WifiDetailsModel WifiDetailsModel 
        {
            get => _wifiDetailsModel;
            set
            {
                _wifiDetailsModel = value;
                NotifyPropertyChanged();
            }
        }

        public SimDetails SimDetails 
        {
            get => _simDetails;
            set
            {
                _simDetails = value;
                NotifyPropertyChanged();
            }
        }

        public BluetoothDetailsModel BluetoothDetailsModel
        {
            get => _bluetoothDetailsModel;
            set
            {
                _bluetoothDetailsModel = value;
                NotifyPropertyChanged();
            }
        }

        public HardwareDetailsViewmodel()
        {
            Versions = "214";
            initConfig();
            GetDeviceDetails();
            GetBatteryDetails();
            MobileUtils.Instance.TimerWrap.Elapsed+=GetRamDetails;
            MobileUtils.Instance.TimerWrap.Elapsed += GetRomDetails;
            GetConnectivityDetails();
            MobileUtils.Instance.TimerWrap.Elapsed +=GetWifiDetails;
            GetMobileSignalDetails();
             GetBluetoothDetails();
        }

        private void initConfig()
        {
            BatteryDetails = new BatteryDetailsModel();
            ConnectivityDetailsModel = new ConnectivityDetailsModel();
            WifiDetailsModel = new WifiDetailsModel();
            SimDetails = new SimDetails();
           // BluetoothDetailsModel= new BluetoothDetailsModel();
        }

        public ObservableCollection<MasterItemContentView> PopulateFlexiModelItems()
        {
            var masterItemContentViews=new ObservableCollection<MasterItemContentView>();

            masterItemContentViews.Add(new MasterItemContentView("Battery", nameof(BatteryDetails.Chargelevel), nameof(BatteryDetails.Powersource), BatteryDetails));

            masterItemContentViews.Add(new MasterItemContentView("Ram", nameof(RamDetails.PercentageUsed), nameof(RamDetails.RamUsed), RamDetails));

            masterItemContentViews.Add(new MasterItemContentView("Memory", nameof(RomDetailsModel.PercentageMemory), nameof(RomDetailsModel.AvailableMemory), RomDetailsModel));

            masterItemContentViews.Add(new MasterItemContentView("Internet", nameof(ConnectivityDetailsModel.Connected), nameof(ConnectivityDetailsModel.Profile), ConnectivityDetailsModel));

            masterItemContentViews.Add(new MasterItemContentView("Wifi", nameof(ConnectivityDetailsModel.Connected), nameof(ConnectivityDetailsModel.Profile), ConnectivityDetailsModel));
            
            masterItemContentViews.Add(new MasterItemContentView("Bluetooth", nameof(BluetoothDetailsModel.BluetoothStatus), nameof(BluetoothDetailsModel.BluetoothName), BluetoothDetailsModel));

            masterItemContentViews.Add(new MasterItemContentView("Mobile Signal", nameof(SimDetails.SimStrength), nameof(SimDetails.SimStrength), SimDetails));

            return masterItemContentViews;
        }

        private void updateFlexiItem(FlexiItemEnum flexiItemEnum)
        {

        }

        public void GetDeviceDetails()
        {
            //Versions = DependencyService.Get<IServiceWrapper>().getDeviceDetails();
        }


        public void MemoryDetails()
        {
            RomDetailsModel = DependencyService.Get<IServiceWrapper>().getRomDetails();
        }

        public void GetBatteryDetails()
        {
            getBatteryDetails();
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            Battery.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;
            //BatteryDetails= DependencyService.Get<IServiceWrapper>().getBatteryDetails();
        }

        public void GetConnectivityDetails()
        {
            ConnectivityDetailsModel.Connected = Connectivity.NetworkAccess.ToString();
            if(Connectivity.NetworkAccess==NetworkAccess.Internet)
            {
                ConnectivityDetailsModel.Profile = string.Empty;
                foreach (var profile in Connectivity.ConnectionProfiles)
                {
                    ConnectivityDetailsModel.Profile += profile + " ";
                }
            }
            else
            {
                ConnectivityDetailsModel.Profile = "";
            }
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        public async void GetWifiDetails(object e, ElapsedEventArgs elapsedEventArgs)
        {
           // await getGeoLocation();
            WifiDetailsModel = DependencyService.Get<IServiceWrapper>().GetWifiDetails();
            Debug.Write(WifiDetailsModel);
        }

        private async Task getGeoLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            var cts = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, cts.Token);

            if (location != null)
            {
                Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
            }
        }


        public void GetMobileSignalDetails()
        {
            SimDetails.SimStrength = DependencyService.Get<IServiceWrapper>().GetMobileSignalDetails();
        }

        public void GetBluetoothDetails()
        {
            BluetoothDetailsModel = DependencyService.Get<IServiceWrapper>().GetBluetoothDetails();
        }

        public void BluetoothEvent(object sender, BluetoothDetailsModel e)
        {
            BluetoothDetailsModel = e;
        }

        #region Battery
        private void getBatteryDetails()
        {
            BatteryDetails.State = Battery.State.ToString();
            BatteryDetails.Powersource= Battery.PowerSource.ToString();
            BatteryDetails.Energysaverstatus = Battery.EnergySaverStatus.ToString();
            BatteryDetails.Chargelevel =  (Battery.ChargeLevel*100).ToString();
        }
        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            getBatteryDetails();
            BatteryDetails.Chargelevel= (e.ChargeLevel * 100).ToString();
            BatteryDetails.State= e.State.ToString();
            BatteryDetails.Powersource= e.PowerSource.ToString();
        }

        private void Battery_EnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
        {
            getBatteryDetails();
            BatteryDetails.Energysaverstatus = e.EnergySaverStatus.ToString();
        }
        #endregion

        #region RAM
        public void GetRamDetails(object e, ElapsedEventArgs elapsedEventArgs)
        {
            RamDetails = DependencyService.Get<IServiceWrapper>().getRamDetails();
        }

        public void GetRomDetails(object e, ElapsedEventArgs elapsedEventArgs)
        {
            RomDetailsModel = DependencyService.Get<IServiceWrapper>().getRomDetails();
        }
        #endregion

        #region InternetConnectivity
        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            ConnectivityDetailsModel.Connected = e.NetworkAccess.ToString();
            if (e.NetworkAccess == NetworkAccess.Internet)
            {
                ConnectivityDetailsModel.Profile = string.Empty;
                foreach (var profile in e.ConnectionProfiles)
                {
                    ConnectivityDetailsModel.Profile += profile + ",";
                }
            }
            else
            {
                ConnectivityDetailsModel.Profile = "";
            }
        }
        #endregion
    }
}
