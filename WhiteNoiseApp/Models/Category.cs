using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WhiteNoiseApp.Models
{
    public class Category
    {
        public string Title { get; set; }
        public ObservableCollection<SoundSample> SoundsList { get; set; }
    }
}
