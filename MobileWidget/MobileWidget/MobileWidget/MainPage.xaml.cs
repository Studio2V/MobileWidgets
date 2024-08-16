using MobileWidget.Viewmodel;
using MobileWidget.Views.ContentViews;
using Xamarin.Forms;

namespace MobileWidget
{
    public partial class MainPage : ContentPage
    {
        HardwareDetailsViewmodel hardwareDetailsViewmodel = HardwareDetailsViewmodel.Instance;
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = hardwareDetailsViewmodel;
            populateModelItem();
        }

        private void populateModelItem()
        {
           var items= hardwareDetailsViewmodel.PopulateFlexiModelItems();
           foreach(var item in items)
           {
                flexlayoutItem.Children.Add(item);
           }
        }
    }
}
