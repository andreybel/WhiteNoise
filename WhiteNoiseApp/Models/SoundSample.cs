using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhiteNoiseApp.Models
{
    public class SoundSample
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public double IconSize { get; set; } = 0.8;
        public Color IconColor { get; set; } 
        public string Description { get; set; }
        public bool IsFavorites { get; set; }
        public bool IsSelected { get; set; }

    }
}
