using MobileWidget.Models;
using System.Diagnostics;

namespace MobileWidget.ServiceWrapper
{
    public interface IServiceWrapper
    {
        DeviceDetails getDeviceDetails();

        RamDetailsModel getRamDetails();

        RomDetailsModel getRomDetails();

        WifiDetailsModel GetWifiDetails();

        string GetMobileSignalDetails();
        BluetoothDetailsModel GetBluetoothDetails();
    }
}
