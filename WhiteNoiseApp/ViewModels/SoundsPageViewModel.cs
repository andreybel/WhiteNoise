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
                new SoundSample{Name="relax"},
                new SoundSample{Name="nature"},
                new SoundSample{Name="piano"},
                new SoundSample{Name="wind"},
                new SoundSample{Name="rain"},
                new SoundSample{Name="sea"},
                new SoundSample{Name="city"},
                new SoundSample{Name="space"},
                new SoundSample{Name="aimals"},
                new SoundSample{Name="birds"},
                new SoundSample{Name="technick"},
                new SoundSample{Name="random"},
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
