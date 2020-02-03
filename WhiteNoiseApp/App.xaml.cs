using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Plugin.Iconize;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Plugin.Popups;
using Prism.Unity;
using WhiteNoiseApp.Interfaces;
using WhiteNoiseApp.Resources;
using WhiteNoiseApp.Services;
using WhiteNoiseApp.ViewModels;
using WhiteNoiseApp.ViewModels.Popups;
using WhiteNoiseApp.Views;
using WhiteNoiseApp.Views.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WhiteNoiseApp
{
    public partial class App: PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) 
        {
            AppResource.Culture = DependencyService.Get<ILocalizeService>()
                                .GetCurrentCultureInfo();
        }

        public App(IPlatformInitializer initializer) : base(initializer){}

        protected override void OnInitialized()
        {
            InitializeComponent();

            Xamarin.Forms.Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental",
                "SwipeView_Experimental"});



            MainPage = new SoundsPage();
        }
        protected override void Initialize()
        {
            base.Initialize();
            Iconize
                .With(new Plugin.Iconize.Fonts.FontAwesomeRegularModule())
                .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
                .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterPopupNavigationService();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SoundsPage, SoundsPageViewModel>();
            containerRegistry.RegisterForNavigation<PlaySoundPage, PlaySoundPageViewModel>();
            containerRegistry.RegisterForNavigation<FavoritesPage, FavoritesPageViewModel>();
            containerRegistry.RegisterForNavigation<VolumePopupPage, VolumePopupPageViewModel>();
            containerRegistry.RegisterForNavigation<TimerPopupPage, TimerPopupPageViewModel>();

            containerRegistry.Register<IAudioPlayerService, AudioPlayerService>();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=d795e1c8-369c-48e1-b99f-31b8e408dec1;", 
                  typeof(Analytics), typeof(Crashes));
            base.OnStart();
        }
    }
}
