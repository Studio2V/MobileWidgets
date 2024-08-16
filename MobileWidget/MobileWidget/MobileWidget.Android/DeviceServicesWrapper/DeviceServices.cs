using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Content.PM;
using Android.Net.Wifi;
using Android.OS;
using Android.Provider;
using Android.Systems;
using Android.Telephony;
using Android.Util;
using MobileWidget.Models;
using MobileWidget.ServiceWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using Xamarin.Forms;
using Context = Android.Content.Context;

[assembly: Dependency(typeof(MobileWidget.Droid.DeviceServicesWrapper.DeviceServices))]
namespace MobileWidget.Droid.DeviceServicesWrapper
{
    public class DeviceServices : IServiceWrapper
    {
        public DeviceServices()
        {
            PermissionWrapper.getPermissionWrapperInstance((Activity)Forms.Context);
        }

        public DeviceDetails getDeviceDetails()
        {
            //var details=new DeviceDetails()
            //{

            //}
            var s=string.Empty;
            s = $"Brand: ${Build.Brand} \n" +
                $"Model: ${Build.Model} \n" +
                $"ID: ${Build.Id} \n" +
                $"SDK: ${Build.VERSION.Sdk} \n" +
                $"SDKInt: ${Build.VERSION.SdkInt} \n" +
                $"Manufacture: ${Build.Manufacturer} \n" +
                $"Soc Manufacture: ${Build.SocManufacturer} \n" +
                $"Soc Model: ${Build.SocModel} \n" +
                $"Brand: ${Build.Brand} \n" +
                $"User: ${Build.User} \n" +
                //$"Type: ${Build.Type} \n" +
                //$"Base: ${Build.vers} \n" +
                //$"Base: ${Build.VERSION_CODES.Base11} \n" +
                $"Incremental: ${Build.VERSION.Incremental} \n" +
                $"Board: ${Build.Board} \n" +
                $"Host: ${Build.Host} \n" +
                $"FingerPrint: ${Build.Fingerprint} \n" +
                $"Release: ${Build.VERSION.Release}" +
                $"Release Name: ${Build.VERSION.ReleaseOrCodename}";
            return new DeviceDetails();
        }

        public RamDetailsModel getRamDetails()
        {
            RamDetailsModel model = new RamDetailsModel();
            ActivityManager actManager = (ActivityManager)((Activity)Forms.Context).GetSystemService(Context.ActivityService);
            ActivityManager.MemoryInfo memInfo = new ActivityManager.MemoryInfo();
            actManager.GetMemoryInfo(memInfo);
            model.RamLow = memInfo.LowMemory.ToString();
            model.RamCapacity = Common.Converter.FormatSize(memInfo.TotalMem);
            model.RamUsed = Common.Converter.FormatSize(memInfo.AvailMem);
            model.PercentageUsed= string.Format("{0:0.00}",((memInfo.AvailMem /(double)memInfo.TotalMem) * 100.0))+"%";
            return model;
        }

        public RomDetailsModel getRomDetails()
        {
            var k = new RomDetailsModel();
            var iPath = Android.OS.Environment.ExternalStorageDirectory;
            StatFs iStat = new StatFs(iPath.Path);
            var iBlockSize = iStat.BlockSizeLong;
            var iAvailableBlocks = iStat.AvailableBlocksLong;
            var iTotalBlocks = iStat.BlockCountLong;
            var iUsedBlocks = iTotalBlocks - iAvailableBlocks;
            k.AvailableMemory = Common.Converter.FormatSize(iAvailableBlocks * iBlockSize);
            k.TotalMemory = Common.Converter.FormatSize(iTotalBlocks * iBlockSize);
            k.UsedMemory = Common.Converter.FormatSize(iTotalBlocks * iBlockSize-iAvailableBlocks * iBlockSize);
            k.PercentageMemory =string.Format("{0:0.00}",((iUsedBlocks * iBlockSize) /(double)(iTotalBlocks * iBlockSize))*100.0)+"%";
            return k;
        }

        [Obsolete]
        public WifiDetailsModel GetWifiDetails()
        {
            try
            {
                PermissionWrapper.Instance.getGeoLocationAsync();


                //if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
                //{
                //    // can also use `Settings.Panel.ACTION_WIFI` to enable/disable only WiFi
                //    var panelIntent = new Intent(Settings.Panel.ActionInternetConnectivity);
                //    ((Activity)Forms.Context).StartActivityForResult(panelIntent, 0);
                //}
                //else
                //{
                //    // use previous solution, add appropriate permissions to AndroidManifest file (see answers above)
                //    (((Activity)Forms.Context).GetSystemService(Context.WifiService) as WifiManager).SetWifiEnabled(false); /*or false*/
                //}

                WifiDetailsModel wifiDetailsModel = new WifiDetailsModel();
                WifiManager wifiManager = (WifiManager)((Activity)Forms.Context).GetSystemService(Context.WifiService);
                var z=wifiManager.SetWifiEnabled(true);
                WifiInfo info = wifiManager.ConnectionInfo;
                string ssid = info.SSID;

                wifiDetailsModel.Ssid = ssid;
                return wifiDetailsModel;
            }
            catch(Exception e)
            {
                _ = e;
                return new WifiDetailsModel();
            }
        }

        public string GetMobileSignalDetails()
        {
            var telephonyManager = (TelephonyManager)((Activity)Forms.Context).GetSystemService(Context.TelephonyService);
            //telephonyManager.Listen();
            //var j=telephonyManager.AllCellInfo.ToList();
            //var m = j[0].CellSignalStrength;
            return telephonyManager.SignalStrength.Level.ToString();
        }

        public BluetoothDetailsModel GetBluetoothDetails()
        {
            var result=new BluetoothDetailsModel();
            PermissionWrapper.Instance.getBluetoothPermissionAsync();
            BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            
            result.BluetoothName = string.Empty;
            result.BluetoothStatus = (bluetoothAdapter.State== State.Connected)?"Connected":"Not Connected";
            GetAppsList();
            return result;
        }

        public void GetAppsList()
        {
            Intent mainIntent = new Intent(Intent.ActionMain, null);
            mainIntent.AddCategory(Intent.CategoryLauncher);
            var pkgAppsList =((Activity)Forms.Context).PackageManager.GetInstalledApplications(PackageInfoFlags.Activities);
            foreach(var i in pkgAppsList)
            {
                if (i.Name == null)
                    continue;
                Log.Debug(i.Name,i.Name);
                Console.WriteLine(i.Name);
            }
        }

    }
}