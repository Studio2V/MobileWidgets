using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileWidget.Views.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterItemContentView : Frame
    {
        public MasterItemContentView(string h1propertyPath, string h2propertyPath, string h3propertyPath, object bindable)
        {
            InitializeComponent();
            this.Content.BindingContext = this;

            H1Label.Text = h1propertyPath;

            H2Label.BindingContext = bindable;
            H2Label.SetBinding(Label.TextProperty, path: h2propertyPath);

            H3Label.BindingContext = bindable;
            H3Label.SetBinding(Label.TextProperty, path: h3propertyPath);
        }
    }
}