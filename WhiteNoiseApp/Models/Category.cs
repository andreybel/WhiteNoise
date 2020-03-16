using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace WhiteNoiseApp.Models
{
    public class Category
    {
        public string Title { get; set; }
        public string BackgroundImage { get; set; }
        public List<SoundSample> SoundsList { get; set; }

        public SoundSample SelectedSound { get; set; }
    }
}
