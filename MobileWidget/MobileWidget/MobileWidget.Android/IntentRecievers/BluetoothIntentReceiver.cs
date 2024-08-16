using Android.App;
using Android.Bluetooth;
using Android.Content;
using MobileWidget.Droid.DeviceServicesWrapper;
using MobileWidget.Models;
using MobileWidget.Viewmodel;
using System;

namespace MobileWidget.Droid.IntentRecievers
{
    [BroadcastReceiver(Enabled = true,Exported =true)]
    [IntentFilter(new[] { BluetoothAdapter.ActionStateChanged,BluetoothAdapter.ActionConnectionStateChanged})]
    public class BluetoothIntentReceiver : BroadcastReceiver
    {
        public event EventHandler<BluetoothDetailsModel> BluetoothEvent; 
        public override void OnReceive(Context context, Intent intent)
        {
            BluetoothEvent += HardwareDetailsViewmodel.Instance.BluetoothEvent;
            BluetoothEvent.Invoke(this,GetBluetoothDetails());
        }

        public BluetoothDetailsModel GetBluetoothDetails()
        {
            var result = new BluetoothDetailsModel();
            PermissionWrapper.Instance.getBluetoothPermissionAsync();
            BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;

            result.BluetoothName = string.Empty;
            result.BluetoothStatus = (bluetoothAdapter.IsEnabled) ? "Connected" : "Not Connected";
            return result;
        }
    }


}