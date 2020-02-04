using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WhiteNoiseApp.Models;
using WhiteNoiseApp.Resources;
using Xamarin.Forms;

namespace WhiteNoiseApp.ViewModels.Popups
{
    public class TimerPopupPageViewModel : ViewModelBase
    {
        #region fields
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        #endregion 
        public TimerPopupPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;

            SoundTimers = new ObservableCollection<SoundTimer> 
            {   
                new SoundTimer{Time="1"},
                new SoundTimer{Time="5"},
                new SoundTimer{Time="10"},
                new SoundTimer{Time="20"},
                new SoundTimer{Time="30"},
                new SoundTimer{Time="40"},
                new SoundTimer{Time="50"},
                new SoundTimer{Time="60"}
            };
        }

        #region properties
        private ObservableCollection<SoundTimer> _soundTimers;
        public ObservableCollection<SoundTimer> SoundTimers
        {
            get => _soundTimers;
            set => SetProperty(ref _soundTimers, value);
        }
        #endregion

        #region commands
        private DelegateCommand<SoundTimer> _startTimerCommand;

        public DelegateCommand<SoundTimer> StartTimerCommand => _startTimerCommand ?? (_startTimerCommand = new DelegateCommand<SoundTimer>(OnStartTimer));

        private void OnStartTimer(SoundTimer soundTimer)
        {
            if (soundTimer != null)
            {
                _navigationService.GoBackAsync(new NavigationParameters 
                {
                    {nameof(SoundTimer), soundTimer }
                });
            }
            else
            {
                _pageDialogService.DisplayAlertAsync(AppResource.Warning, AppResource.UnhandledError,"OK");
                PopupNavigation.Instance.PopAsync();
            }
        }
        #endregion

        #region privates
        #endregion
    }
}
