﻿using MediaManager;
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
using WhiteNoiseApp.Views.Popups;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;
using Xamarin.Essentials;
using System.Diagnostics;
using System.Threading;

namespace WhiteNoiseApp.ViewModels
{
    public class SoundsPageViewModel : ViewModelBase
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
                new SoundSample{Name=AppResource.Rain, Icon="fas-cloud-moon-rain", Path = Constants.Constants.Rain},
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

        #endregion

        #region commands
        private DelegateCommand<SoundSample>_playSoundCommand;

        public DelegateCommand<SoundSample> PlaySoundCommand => (_playSoundCommand 
            ?? (_playSoundCommand = new DelegateCommand<SoundSample>(OnPlaySound)));

        private async void OnPlaySound(SoundSample soundSample)
        {
            if (string.IsNullOrEmpty(soundSample.Path))
                await _pageDialogService.DisplayAlertAsync(null,"no file", "OK");
            else
            {
                IsPlaying = true;
                await CrossMediaManager.Current.PlayFromAssembly(soundSample.Path);
                CrossMediaManager.Current.RepeatMode = MediaManager.Playback.RepeatMode.One;
            }
        }

        private DelegateCommand _stopCommand;
        public DelegateCommand StopCommand => (_stopCommand ?? (_stopCommand = new DelegateCommand(OnStopSound)));

        private async void OnStopSound()
        {
            IsPlaying = false;
            IsPaused = true;
            await CrossMediaManager.Current.Stop();
        }

        private DelegateCommand _pauseCommand;
        public DelegateCommand PauseCommand => (_pauseCommand ?? (_pauseCommand = new DelegateCommand(OnPause)));

        private void OnPause()
        {
            if (CrossMediaManager.Current.IsPlaying())
                IsPaused = false;
            else
                IsPaused = true;
            CrossMediaManager.Current.PlayPause();
        }

        private DelegateCommand _volumeCommand;

        public DelegateCommand VolumeCommand => (_volumeCommand ?? (_volumeCommand = new DelegateCommand(OnVolume)));

        private async void OnVolume()
        {
            await _navigationService.NavigateAsync(nameof(VolumePopupPage));
        }

        private DelegateCommand _timerCommand;

        public DelegateCommand TimerCommand => (_timerCommand ?? (_timerCommand = new DelegateCommand(OnTimer)));

        private async void OnTimer()
        {
            await _navigationService.NavigateAsync(nameof(TimerPopupPage));
        }
        #endregion

        #region overrides
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Debug.WriteLine("SoundsPageViewModel OnNavigatedTo()");
            if (parameters.TryGetValue(nameof(SoundTimer), out SoundTimer soundTimer))
            {
                var timeSpan = double.Parse(soundTimer.Time);
                Debug.WriteLine(soundTimer.Time + " min. timer started. Time: "+ DateTime.Now.TimeOfDay.ToString());
                Device.StartTimer(TimeSpan.FromMinutes(timeSpan), (() => StopPlaying()));
            }
            base.OnNavigatedTo(parameters);
        }
        #endregion

        #region privates
        private bool StopPlaying()
        {
            CrossMediaManager.Current.Stop();
            Debug.WriteLine("Timer stopped. Time: " + DateTime.Now.TimeOfDay.ToString());
            IsPlaying = false;
            return false;
        }
        #endregion
    }
}       
