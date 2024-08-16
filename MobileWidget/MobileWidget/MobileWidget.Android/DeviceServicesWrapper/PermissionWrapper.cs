using Android;
using Android.Content;
using AndroidX.Core.App;
using System;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.Android;

namespace MobileWidget.Droid.DeviceServicesWrapper
{
    public class PermissionWrapper
    {
        private static Context mContext;
        private static PermissionWrapper instance;
        public static PermissionWrapper Instance
        {
            get
            {
               instance=instance ?? (instance=new PermissionWrapper());
               return instance;
            }
        }

        private PermissionWrapper()
        {

        }

        public static PermissionWrapper getPermissionWrapperInstance(Context context)
        {
            mContext=context;
            return Instance;
        }

        public void getGeoLocationAsync()
        {
             RequestWrapper(Manifest.Permission.AccessFineLocation);
             RequestWrapper(Manifest.Permission.AccessCoarseLocation);
        }

        public void getBluetoothPermissionAsync()
        {
             RequestWrapper(Manifest.Permission.Bluetooth);
             RequestWrapper(Manifest.Permission.BluetoothConnect);
             RequestWrapper(Manifest.Permission.BluetoothScan);
        }

        private void RequestWrapper(string permissionManifest)
        {
            if (ActivityCompat.CheckSelfPermission(mContext, permissionManifest) != Android.Content.PM.Permission.Granted)
            {
                var requiredPermissions = new String[] { permissionManifest };
                ActivityCompat.RequestPermissions(mContext.GetActivity(), requiredPermissions, 1);
            }
            else
            {
                //ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, );
            }
        }
    }
}