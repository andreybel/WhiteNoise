using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using WhiteNoiseApp.Models;

namespace WhiteNoiseApp.ViewModels
{
    public class PlaySoundPageViewModel : BindableBase, INavigationAware, IDestructible
    {
        public PlaySoundPageViewModel()
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

        public void OnNavigatedTo(INavigationParameters parameters)
        {

        }
        public void Destroy()
        {

        }
    }
}
