using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace WhiteNoiseApp.Views.Popups
{
    public partial class VolumePopupPage : PopupPage
    {
        public VolumePopupPage()
        {
            InitializeComponent();
            //Slider.Value = CrossMediaManager.Current.Volume.CurrentVolume;
        }

        private void OnVolumeChanged(object sender, ValueChangedEventArgs e)
        {
            double value = ((Slider)sender).Value;
            //CrossMediaManager.Current.Volume.CurrentVolume = (int)value;
            //Slider.Maximum = CrossMediaManager.Current.Volume.MaxVolume;
            Slider.Minimum = 0;
        }
    }
}
