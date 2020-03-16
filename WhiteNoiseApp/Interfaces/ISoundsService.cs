using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WhiteNoiseApp.Models;

namespace WhiteNoiseApp.Interfaces
{
    public interface ISoundsService
    {
        List<Category> GetOfflineLibrary();
    }
}
