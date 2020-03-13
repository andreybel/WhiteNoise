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
using System.IO;
using System.Reflection;
using Xamarin.Essentials;
using System.Diagnostics;
using System.Threading;
using Plugin.SimpleAudioPlayer;
using System.Threading.Tasks;
using WhiteNoiseApp.Interfaces;

namespace WhiteNoiseApp.ViewModels
{
    public class SoundsPageViewModel : ViewModelBase
    {
        #region fields
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private readonly IAudioPlayerService _audioPLayerService;
        private readonly IToastMessage _toastMessage;
        private readonly ISoundsService _soundsService;
        private double _timeSpan;
        #endregion

        public SoundsPageViewModel(INavigationService navigationService
            , IPageDialogService pageDialogService
            , IAudioPlayerService audioPlayerService
            , IToastMessage toastMessage
            , ISoundsService soundsService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _audioPLayerService = audioPlayerService;
            _toastMessage = toastMessage;
            _soundsService = soundsService;

            Categories = _soundsService.GetOfflineLibrary();

            if (_audioPLayerService.IsPlaying())
                IsPlaying = true;
        }

        #region properties
        private ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }
        #endregion

        #region commands
        private DelegateCommand<SoundSample>_playSoundCommand;

        public DelegateCommand<SoundSample> PlaySoundCommand => (_playSoundCommand 
            ?? (_playSoundCommand = new DelegateCommand<SoundSample>(OnPlaySound)));

        private async void OnPlaySound(SoundSample soundSample)
        {
            if (string.IsNullOrEmpty(soundSample.Path))
                await _pageDialogService.DisplayAlertAsync(null, AppResource.UnhandledError, "OK");
            else
            {
                IsPlaying = true;
                IsPaused = true;
                _audioPLayerService.Play(soundSample.Path, true);
            }
        }

        private DelegateCommand _stopCommand;
        public DelegateCommand StopCommand => (_stopCommand ?? (_stopCommand = new DelegateCommand(OnStopSound)));

        private void OnStopSound()
        {
            IsPlaying = false;
            IsPaused = true;
            _audioPLayerService.Stop();
        }

        private DelegateCommand _pauseCommand;
        public DelegateCommand PauseCommand => (_pauseCommand ?? (_pauseCommand = new DelegateCommand(OnPause)));

        private void OnPause()
        {
            _audioPLayerService.Pause();
            IsPaused = _audioPLayerService.IsPlaying();

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
                _timeSpan = double.Parse(soundTimer.Time)*60;
                Debug.WriteLine(soundTimer.Time + " min. timer started. Time: "+ DateTime.Now.TimeOfDay.ToString());
                _toastMessage.ShowMessage(AppResource.TimerStarted);
                Device.StartTimer(TimeSpan.FromSeconds(_timeSpan), (() => StopPlaying()));
            }

            base.OnNavigatedTo(parameters);
        }
        #endregion

        #region privates
        private bool StopPlaying()
        {
            _audioPLayerService.Stop();
            IsPlaying = false;
            Debug.WriteLine("Timer stopped. Time: " + DateTime.Now.TimeOfDay.ToString());
            return false;
        }
        #endregion
    }
}       
