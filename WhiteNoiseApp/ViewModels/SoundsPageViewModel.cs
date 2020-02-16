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
        private double _timeSpan;
        #endregion

        public SoundsPageViewModel(INavigationService navigationService
            , IPageDialogService pageDialogService
            , IAudioPlayerService audioPlayerService
            , IToastMessage toastMessage)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            _audioPLayerService = audioPlayerService;
            _toastMessage = toastMessage;

            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Title = AppResource.Nature,
                    BackgroundImage = Helpers.ImageNameHelper.BgImage,
                    SoundsList = new ObservableCollection<SoundSample>
                    {
                        new SoundSample{Name=AppResource.Fireplace, Icon = Helpers.ImageNameHelper.FirePLace, Path = Constants.Constants.Fireplace},
                        new SoundSample{Name=AppResource.Forest, Icon=Helpers.ImageNameHelper.Forest, Path = Constants.Constants.Forest},
                        new SoundSample{Name=AppResource.Storm, Icon=Helpers.ImageNameHelper.Storm, Path = Constants.Constants.Thunder},
                        new SoundSample{Name=AppResource.Rain, Icon=Helpers.ImageNameHelper.Rain, Path = Constants.Constants.SmallRain},
                        new SoundSample{Name=AppResource.Sea, Icon = Helpers.ImageNameHelper.Sea, Path = Constants.Constants.Sea},
                        new SoundSample{Name=AppResource.Space, Icon = Helpers.ImageNameHelper.Night, Path = Constants.Constants.Space},
                        new SoundSample{Name=AppResource.Bonfire, Icon = Helpers.ImageNameHelper.Bonfire1, Path = Constants.Constants.Bonfire},
                        new SoundSample{Name=AppResource.Night, Icon = Helpers.ImageNameHelper.NightForest, Path = Constants.Constants.Night},
                        new SoundSample{Name=AppResource.Snowstorm, Icon = Helpers.ImageNameHelper.SnowStorm, Path = Constants.Constants.Snowstorm}
                    }
                },
                new Category
                {
                    Title = AppResource.Technick,
                    BackgroundImage = Helpers.ImageNameHelper.BgImage1,
                    SoundsList = new ObservableCollection<SoundSample>
                    {
                        new SoundSample{Name=AppResource.City, Icon = Helpers.ImageNameHelper.City, Path = Constants.Constants.City},
                        new SoundSample{Name=AppResource.Helicopter, Icon = Helpers.ImageNameHelper.Helicopter, Path = Constants.Constants.Helicopter},
                        new SoundSample{Name=AppResource.Keyboard, Icon = Helpers.ImageNameHelper.Keyboard, Path = Constants.Constants.Keyboard},
                        new SoundSample{Name=AppResource.Mixer, Icon = Helpers.ImageNameHelper.Mixer, Path = Constants.Constants.Mixer},
                        new SoundSample{Name=AppResource.CoffeeMashine, Icon = Helpers.ImageNameHelper.CoffeeMashine, Path = Constants.Constants.CoffeeMashine},
                        new SoundSample{Name=AppResource.Train, Icon = Helpers.ImageNameHelper.Train, Path = Constants.Constants.Train},
                        new SoundSample{Name=AppResource.Calculator, Icon = Helpers.ImageNameHelper.Calculator, Path = Constants.Constants.Calculator},
                        new SoundSample{Name=AppResource.Laminator, Icon = Helpers.ImageNameHelper.Laminator, Path = Constants.Constants.Laminator},
                        new SoundSample{Name=AppResource.Sail, Icon = Helpers.ImageNameHelper.Sail, Path = Constants.Constants.Sail}
                    }
                },
                new Category
                {
                    Title = AppResource.ASMR,
                    BackgroundImage = Helpers.ImageNameHelper.BgImage2,
                    SoundsList = new ObservableCollection<SoundSample>
                    {
                        new SoundSample{Name=AppResource.Cats, Icon = Helpers.ImageNameHelper.Cat, Path = Constants.Constants.Cat},
                        new SoundSample{Name=AppResource.Birds, Icon = Helpers.ImageNameHelper.Bird, Path = Constants.Constants.Birds},
                        new SoundSample{Name=AppResource.Sea, Icon = Helpers.ImageNameHelper.UnderWater, Path = Constants.Constants.UnderWater},
                        new SoundSample{Name=AppResource.Snow, Icon = Helpers.ImageNameHelper.Snow, Path = Constants.Constants.Snow},
                        new SoundSample{Name=AppResource.Pen, Icon = Helpers.ImageNameHelper.Pen, Path = Constants.Constants.Pen},
                        new SoundSample{Name=AppResource.Pencil, Icon = Helpers.ImageNameHelper.Pencil, Path = Constants.Constants.Pencil},
                        new SoundSample{Name=AppResource.Scissors, Icon = Helpers.ImageNameHelper.Scissors, Path = Constants.Constants.Scissors},
                        new SoundSample{Name=AppResource.Chalk, Icon = Helpers.ImageNameHelper.Chalk, Path = Constants.Constants.Chalk},
                        new SoundSample{Name=AppResource.Clock, Icon = Helpers.ImageNameHelper.Clock, Path = Constants.Constants.Clock}
                        
                    }
                },
                new Category
                {
                    Title = AppResource.Instrumental,
                    BackgroundImage = Helpers.ImageNameHelper.BgImage3,
                    SoundsList = new ObservableCollection<SoundSample>
                    {
                        new SoundSample{Name=AppResource.Harp, Icon = Helpers.ImageNameHelper.Harp, Path = Constants.Constants.Harp},
                        new SoundSample{Name=AppResource.Flute, Icon = Helpers.ImageNameHelper.Flute, Path = Constants.Constants.Flute},
                        new SoundSample{Name=AppResource.Tambourine, Icon = Helpers.ImageNameHelper.Tambourine, Path = Constants.Constants.Tambourine},
                        new SoundSample{Name=AppResource.Piano, Icon = Helpers.ImageNameHelper.Piano, Path = Constants.Constants.Piano},
                        new SoundSample{Name=AppResource.Guitar, Icon = Helpers.ImageNameHelper.Guitar, Path = Constants.Constants.Guitar},
                        new SoundSample{Name=AppResource.Xylophone, Icon = Helpers.ImageNameHelper.Xylophone, Path = Constants.Constants.Xylophone},
                        new SoundSample{Name=AppResource.ElectricGuitar, Icon = Helpers.ImageNameHelper.ElectricGuitar, Path = Constants.Constants.ElectricGuitar},
                        new SoundSample{Name=AppResource.Saxophone, Icon = Helpers.ImageNameHelper.Saxophone, Path = Constants.Constants.Saxophone},
                        new SoundSample{Name=AppResource.Meditation, Icon = Helpers.ImageNameHelper.Meditation, Path = Constants.Constants.Meditation},

                    }
                },
            };
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

        private ObservableCollection<SoundSample> _soundSamples;
        public ObservableCollection<SoundSample> SoundSamples
        {
            get => _soundSamples;
            set => SetProperty(ref _soundSamples, value);
        }

        private string _backGroundImage;
        public string BGImage
        {
            get => _backGroundImage;
            set => SetProperty(ref _backGroundImage, value, OnChangeImage);
        }

        private void OnChangeImage()
        {
            foreach (var category in Categories)
            {
                _backGroundImage = category.BackgroundImage;
                RaisePropertyChanged(BGImage);
            }
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

        private Category GetCategory(string title, ObservableCollection<SoundSample> soundSamples)
        {
            return new Category
            {
                Title = title,
                SoundsList = soundSamples
            };
        }
        #endregion
    }
}       
