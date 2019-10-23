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
                new SoundSample{Name=AppResource.Relax, Icon = "fas-music"},
                new SoundSample{Name=AppResource.Nature, Icon="fas-tree"},
                new SoundSample{Name=AppResource.Wind, Icon="fas-wind"},
                new SoundSample{Name=AppResource.Rain, Icon="fas-cloud-rain"},
                new SoundSample{Name=AppResource.Sea, Icon = "fas-water"},
                new SoundSample{Name=AppResource.City, Icon = "fas-city"},
                new SoundSample{Name=AppResource.Space, Icon = "fas-moon"},
                new SoundSample{Name=AppResource.Animals, Icon = "fas-cat"},
                new SoundSample{Name=AppResource.Birds, Icon = "fas-dragon"},
                new SoundSample{Name=AppResource.Technick, Icon = "fas-blender-phone"},
                new SoundSample{Name=AppResource.Random, Icon = "fas-random"},
                new SoundSample{Name=AppResource.MySample, Icon = "fas-microphone-alt"},
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

        public DelegateCommand PlaySoundCommand => (_playSoundCommand ?? 
            (_playSoundCommand = new DelegateCommand(OnPlaySound, () => SelectedSound != null).ObservesProperty(() => SelectedSound)));

        private async void OnPlaySound()
        {
            var parameter = new NavigationParameters();
            parameter.Add("PlaySoundPage",SelectedSound);
            await _navigationService.SelectTabAsync(nameof(PlaySoundPage), parameter);
        }
        #endregion
    }
}       
