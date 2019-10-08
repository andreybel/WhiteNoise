using WhiteNoiseApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace WhiteNoiseApp.Views
{
    public class BottomTabbedPage : TabbedPage
    {
        public BottomTabbedPage()
        {
            On<Android>()
                .SetToolbarPlacement(ToolbarPlacement.Bottom);
            SelectedTabColor = ColorsHelper.SecondaryColor;
            UnselectedTabColor = Color.White;
            BarBackgroundColor = ColorsHelper.PrimaryDarkColor;
            BarTextColor = Color.White;
        }
    }
}
