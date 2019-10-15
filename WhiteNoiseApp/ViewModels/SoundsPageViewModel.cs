using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WhiteNoiseApp.Models;
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
                new SoundSample{Name="relax", Icon = "fas-music"},
                new SoundSample{Name="nature", Icon="fas-tree"},
                new SoundSample{Name="piano", Icon = "fas-music"},
                new SoundSample{Name="wind", Icon="fas-wind"},
                new SoundSample{Name="rain", Icon="fas-cloud-rain"},
                new SoundSample{Name="sea", Icon = "fas-water"},
                new SoundSample{Name="city", Icon = "fas-city"},
                new SoundSample{Name="space", Icon = "fas-moon"},
                new SoundSample{Name="animals", Icon = "fas-cat"},
                new SoundSample{Name="birds", Icon = "fas-dragon"},
                new SoundSample{Name="technick", Icon = "fas-blender-phone"},
                new SoundSample{Name="random", Icon = "fas-random"},
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
        private DelegateCommand _playSoundCommand;

        public DelegateCommand PlaySoundCommand => (_playSoundCommand ?? (_playSoundCommand = new DelegateCommand(OnPlaySound)));

        private async void OnPlaySound()
        {
           await _navigationService.NavigateAsync(nameof(PlaySoundPage));
        }
        #endregion
    }
}       
