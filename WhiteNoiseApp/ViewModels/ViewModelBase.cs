using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhiteNoiseApp.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {

        #region propeties
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

        private bool _isBusy = true;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        #endregion

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase()
        {
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
