﻿using MediaManager;
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
        }

        private void OnVolumeChanged(object sender, ValueChangedEventArgs e)
        {
            double value = ((Slider)sender).Value;
            CrossMediaManager.Current.Volume.CurrentVolume = (int)value;
            CrossMediaManager.Current.Volume.MaxVolume = (int)Slider.Maximum;
        }
    }
}
