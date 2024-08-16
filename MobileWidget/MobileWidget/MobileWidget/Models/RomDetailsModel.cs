using MobileWidget.Viewmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileWidget.Models
{
    public class RomDetailsModel : BaseViewModel
    {
        private string _usedMemory;

        private string _totalMemory;

        private string _availableMemory;

        private string _percentageMemory;

        public string UsedMemory 
        {
            get => _usedMemory;
            set
            {
                _usedMemory = value;
                NotifyPropertyChanged();
            }
        }
        
        public string TotalMemory 
        {
            get => _totalMemory;
            set 
            {
                _totalMemory = value;
                NotifyPropertyChanged();
            }
        }

        public string AvailableMemory 
        {
            get => _availableMemory;
            set
            {
                _availableMemory = value;
                NotifyPropertyChanged();
            }
        }

        public string PercentageMemory 
        {
            get => _percentageMemory;
            set
            {
                _percentageMemory = value;
                NotifyPropertyChanged();
            }
        }
    }
}
