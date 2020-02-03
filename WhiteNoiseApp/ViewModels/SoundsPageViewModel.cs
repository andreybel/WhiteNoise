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

namespace WhiteNoiseApp.ViewModels
{
    public class SoundsPageViewModel : ViewModelBase
    {
        #region fields
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        private ISimpleAudioPlayer player;
        #endregion

        public SoundsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
            player = CrossSimpleAudioPlayer.Current;

            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Title = AppResource.Nature,
                    SoundsList = new ObservableCollection<SoundSample>
                    {
                        new SoundSample{Name=AppResource.Fireplace, Icon = Helpers.ImageNameHelper.FirePLace, Path = Constants.Constants.Fireplace},
                        new SoundSample{Name=AppResource.Forest, Icon=Helpers.ImageNameHelper.Forest, Path = Constants.Constants.Forest},
                        new SoundSample{Name=AppResource.Storm, Icon=Helpers.ImageNameHelper.Storm, Path = Constants.Constants.Thunder},
                        new SoundSample{Name=AppResource.Rain, Icon=Helpers.ImageNameHelper.Rain, Path = Constants.Constants.SmallRain},
                        new SoundSample{Name=AppResource.Sea, Icon = Helpers.ImageNameHelper.Sea, Path = Constants.Constants.Sea},
                        new SoundSample{Name=AppResource.Space, Icon = Helpers.ImageNameHelper.Night, Path = Constants.Constants.Space},
                        new SoundSample{Name=AppResource.Bonfire, Icon = Helpers.ImageNameHelper.Bonfire, Path = Constants.Constants.Bonfire},
                        new SoundSample{Name=AppResource.Night, Icon = Helpers.ImageNameHelper.NightForest, Path = Constants.Constants.Night},
                        new SoundSample{Name=AppResource.Snowstorm, Icon = Helpers.ImageNameHelper.SnowStorm, Path = Constants.Constants.Snowstorm}
                    }
                },
                new Category
                {
                    Title = AppResource.Technick,
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
                    Title = AppResource.Instruments,
                    SoundsList = new ObservableCollection<SoundSample>
                    {
                        new SoundSample{Name=AppResource.Harp, Icon = Helpers.ImageNameHelper.Harp, Path = Constants.Constants.Harp},
                        new SoundSample{Name=AppResource.Flute, Icon = Helpers.ImageNameHelper.Flute, Path = Constants.Constants.Flute},
                        new SoundSample{Name=AppResource.Tambourine, Icon = Helpers.ImageNameHelper.Tambourine, Path = Constants.Constants.Tambourine}

                    }
                },
            };

            //if (CrossMediaManager.Current.IsPlaying())
            //    IsPlaying = true;
            if (player.IsPlaying)
                IsPlaying = true;
        }

        #region properties


        private Category _category;
        public Category Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        private SoundSample _selectedSound;
        public SoundSample SelectedSound
        {
            get => _selectedSound;
            set => SetProperty(ref _selectedSound, value);
        }

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
                soundSample.IsSelected = true;
                IsPlaying = true;
                IsPaused = true;
                player.Load(GetStreamFromFile(soundSample.Path));
                player.Play();
                player.Loop = true;
                //await CrossMediaManager.Current.PlayFromAssembly(soundSample.Path);
                //CrossMediaManager.Current.RepeatMode = MediaManager.Playback.RepeatMode.One;
                //CrossMediaManager.Current.Queue.Current.FileName = null;
            }
        }

        private DelegateCommand _stopCommand;
        public DelegateCommand StopCommand => (_stopCommand ?? (_stopCommand = new DelegateCommand(OnStopSound)));

        private async void OnStopSound()
        {
            IsPlaying = false;
            IsPaused = true;
            ////await CrossMediaManager.Current.Stop();
            player.Stop();
        }

        private DelegateCommand _pauseCommand;
        public DelegateCommand PauseCommand => (_pauseCommand ?? (_pauseCommand = new DelegateCommand(OnPause)));

        private void OnPause()
        {
            //if (CrossMediaManager.Current.IsPlaying())
            //    IsPaused = false;
            //else
            //    IsPaused = true;
            //CrossMediaManager.Current.PlayPause();

            if (player.IsPlaying)
            {
                IsPaused = false;
                player.Pause();
            }
            else
            {
                IsPaused = true;
                player.Play();
            }

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
            //CrossMediaManager.Current.Stop();
            player.Stop();
            Debug.WriteLine("Timer stopped. Time: " + DateTime.Now.TimeOfDay.ToString());
            IsPlaying = false;
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

        private Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("WhiteNoiseApp.Sounds." + filename);
            return stream;
        }
        #endregion
    }
}       
