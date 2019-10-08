using WhiteNoiseApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace WhiteNoiseApp.Views
{
    public class BottomTabbedPage : TabbedPage
    {
        [System.Obsolete]
        public BottomTabbedPage()
        {
            On<Android>()
                .SetToolbarPlacement(ToolbarPlacement.Bottom);
            SelectedTabColor = ColorsHelper.PrimarySelectColor;
            UnselectedTabColor = ColorsHelper.PrimaryDarkColor;
            BarTextColor = Color.White;
        }
    }
}
