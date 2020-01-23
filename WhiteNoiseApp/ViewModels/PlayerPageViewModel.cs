using MediaManager;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using WhiteNoiseApp.Models;

namespace WhiteNoiseApp.ViewModels
{
    public class PlayerPageViewModel : BindableBase, INavigationAware, IDestructible
    {
        public PlayerPageViewModel()
        {

        }

        #region properties
        private SoundSample _soundSample;
        public SoundSample SoundSample
        {
            get { return _soundSample; }
            set { SetProperty(ref _soundSample, value); }
        }
        #endregion

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            SoundSample = parameters[nameof(SoundSample)] as SoundSample;
            await CrossMediaManager.Current.PlayFromResource("assets:///rain.mp3");
            //await CrossMediaManager.Current.Play("https://www.liquidmindmusic.com/mp3/meditation.mp3");
            //var audioUrl = "android.resource://" + Resources.GetResourcePackageName(Resource.Raw.VideoFile.mp4) + "/" + Resource.Raw.VideoFile;
        }

        public void Destroy()
        {

        }
    }
}
