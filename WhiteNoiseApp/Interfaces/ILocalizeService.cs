using System.Globalization;

namespace WhiteNoiseApp.Interfaces
{
    public interface ILocalizeService
    {
        CultureInfo GetCurrentCultureInfo();
    }
}
