using Android.App;
using Android.Content;
using Android.Net.Wifi;

namespace MobileWidget.Droid.IntentRecievers
{
    //[BroadcastReceiver(Enabled = true, Exported = true)]
    //[IntentFilter(new[] { WifiManager.ExtraWifiState,
    //    WifiManager.ExtraWifiInfo ,
    //    WifiManager.ExtraNetworkInfo ,
    //    WifiManager.NetworkStateChangedAction ,
    //    WifiManager.SupplicantConnectionChangeAction,
    //    WifiManager.SupplicantStateChangedAction,
    //    WifiManager.WifiStateChangedAction,
    //    ConnectivityManager.ConnectivityAction,
    //    ConnectivityManager.ExtraNetwork
    //})]
    public class WifiIntentReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {

        }
    }
}