using Plugin.Iconize;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using WhiteNoiseApp.ViewModels;
using WhiteNoiseApp.Views;
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
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var urlNav =
                $"/{nameof(BottomTabbedPage)}?{KnownNavigationParameters.CreateTab}={nameof(NavigationPage)}|{nameof(SoundsPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(NavigationPage)}|{nameof(PlaySoundPage)}" +
                $"&{KnownNavigationParameters.CreateTab}={nameof(NavigationPage)}|{nameof(FavoritesPage)}";


            await NavigationService.NavigateAsync(urlNav);
            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
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
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BottomTabbedPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SoundsPage, SoundsPageViewModel>();
            containerRegistry.RegisterForNavigation<PlaySoundPage, PlaySoundPageViewModel>();
            containerRegistry.RegisterForNavigation<FavoritesPage, FavoritesPageViewModel>();
            containerRegistry.RegisterForNavigation<MainCarouselPage, MainCarouselPageViewModel>();
        }
    }
}
