using Android.App;
using Android.Bluetooth;
using Android.Content;

namespace MobileWidget.Droid.IntentRecievers
{
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { Android.OS.Storage.StorageManager.ActionManageStorage })]
    internal class StorageIntentReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
        
        }
    }
}