using MobileWidget.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileWidget.Models
{
    public class WifiDetailsModel: BaseViewModel
    {
        private string _ssid;

        public string Ssid 
        {
            get => _ssid;
            set
            {
                _ssid = value;
                NotifyPropertyChanged();
            }
        }
    }
}
