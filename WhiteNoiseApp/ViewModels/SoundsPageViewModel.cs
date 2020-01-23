using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.TabbedPages;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhiteNoiseApp.Models;
using WhiteNoiseApp.Resources;
using WhiteNoiseApp.Views;
using Xamarin.Forms;

namespace WhiteNoiseApp.ViewModels
{
    public class SoundsPageViewModel : BindableBase
    {
        #region fields
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        #endregion

        public SoundsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            SoundSamples = new ObservableCollection<SoundSample>
            {
                new SoundSample{Name=AppResource.Fire, Icon = "fas-fire"},
                new SoundSample{Name=AppResource.Nature, Icon="fas-tree"},
                new SoundSample{Name=AppResource.Storm, Icon="fas-poo-storm"},
                new SoundSample{Name=AppResource.Rain, Icon="fas-cloud-moon-rain"},
                new SoundSample{Name=AppResource.Sea, Icon = "fas-water"},
                new SoundSample{Name=AppResource.City, Icon = "fas-city"},
                new SoundSample{Name=AppResource.Space, Icon = "fas-moon"},
                new SoundSample{Name=AppResource.Animals, Icon = "fas-cat"},
                new SoundSample{Name=AppResource.Birds, Icon = "fas-dove"},
                //new SoundSample{Name=AppResource.Technick, Icon = "fas-blender-phone"},
                //new SoundSample{Name=AppResource.Random, Icon = "fas-random"},
                //new SoundSample{Name=AppResource.MySample, Icon = "fas-microphone-alt"}
            };
        }

        #region properties
        private SoundSample _selectedSound;
        public SoundSample SelectedSound
        {
            get => _selectedSound;
            set => SetProperty(ref _selectedSound, value);
        }

        private ObservableCollection<SoundSample> _soundSamples;
        public ObservableCollection<SoundSample> SoundSamples
        {
            get => _soundSamples;
            set => SetProperty(ref _soundSamples, value);
        }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }

        private bool _isPaused = true;
        public bool IsPaused
        {
            get => _isPaused;
            set => SetProperty(ref _isPaused, value);
        }

        #endregion
        #region commands
        private DelegateCommand<SoundSample>_playSoundCommand;

        public DelegateCommand<SoundSample> PlaySoundCommand => (_playSoundCommand 
            ?? (_playSoundCommand = new DelegateCommand<SoundSample>(OnPlaySound)));

        private void OnPlaySound(SoundSample soundSample)
        {
            IsPlaying = true;
            
            //await _navigationService.NavigateAsync(nameof(PlayerPage)
            //    , new NavigationParameters{ { nameof(SoundSample), soundSample }});
        }

        private DelegateCommand _stopCommand;
        public DelegateCommand StopCommand => (_stopCommand ?? (_stopCommand = new DelegateCommand(OnStopSound)));

        private void OnStopSound()
        {
            IsPlaying = false;
        }

        private DelegateCommand _pauseCommand;
        public DelegateCommand PauseCommand => (_pauseCommand ?? (_pauseCommand = new DelegateCommand(OnPause)));

        private void OnPause()
        {
            if (IsPaused)
                IsPaused = false;
            else
                IsPaused = true;
        }

        private DelegateCommand<SoundSample> _settingsCommand;

        public DelegateCommand<SoundSample> SettingsCommand => (_settingsCommand 
            ?? (_settingsCommand = new DelegateCommand<SoundSample>(OnSettings)));

        private async void OnSettings(SoundSample soundSample)
        {
            await _navigationService.NavigateAsync(nameof(PlayerPage)
                , new NavigationParameters { { nameof(SoundSample), soundSample } });
        }
        #endregion
    }
}       
