using Plugin.SimpleAudioPlayer;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace WhiteNoiseApp.Views.Popups
{
    public partial class VolumePopupPage : PopupPage
    {
        ISimpleAudioPlayer player;
        public VolumePopupPage()
        {
            InitializeComponent();
            player = CrossSimpleAudioPlayer.Current;
            Slider.Value = player.Volume;
        }

        private void OnVolumeChanged(object sender, ValueChangedEventArgs e)
        {
            double value = ((Slider)sender).Value;
            player.Volume = Slider.Value;
        }
    }
}
