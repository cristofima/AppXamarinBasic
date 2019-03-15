using AppXamarin.CustomControl;
using AppXamarin.UWP.Renderers;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace AppXamarin.UWP.Renderers
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderBrush = new SolidColorBrush(Colors.Blue);
                Control.Background = new SolidColorBrush(Colors.Cyan);
                Control.BackgroundFocusBrush = new SolidColorBrush(Colors.Cyan);
            }
        }
    }
}