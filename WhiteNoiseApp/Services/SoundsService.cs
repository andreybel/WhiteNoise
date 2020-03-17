using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using WhiteNoiseApp.Interfaces;
using WhiteNoiseApp.Models;
using WhiteNoiseApp.Resources;
using Xamarin.Forms;

namespace WhiteNoiseApp.Services
{
    public class SoundsService : ISoundsService
    {
        public List<Category> GetOfflineLibrary()
        {
            return new List<Category>
            {
                new Category
                {
                    Title = AppResource.Nature,
                    BackgroundImage = Helpers.ImageNameHelper.BgImage,
                    GradientEndColor = Color.DarkSeaGreen,
                    SoundsList = new List<SoundSample>
                    {
                        new SoundSample{Name=AppResource.Fireplace, Icon = Helpers.ImageNameHelper.FirePLace, Path = Constants.Constants.Fireplace},
                        new SoundSample{Name=AppResource.Forest, Icon=Helpers.ImageNameHelper.Forest, Path = Constants.Constants.Forest},
                        new SoundSample{Name=AppResource.Storm, Icon=Helpers.ImageNameHelper.Storm, Path = Constants.Constants.Thunder},
                        new SoundSample{Name=AppResource.Rain, Icon=Helpers.ImageNameHelper.Rain, Path = Constants.Constants.SmallRain},
                        new SoundSample{Name=AppResource.Sea, Icon = Helpers.ImageNameHelper.Sea, Path = Constants.Constants.Sea},
                        new SoundSample{Name=AppResource.Space, Icon = Helpers.ImageNameHelper.Night, Path = Constants.Constants.Space},
                        new SoundSample{Name=AppResource.Bonfire, Icon = Helpers.ImageNameHelper.Bonfire1, Path = Constants.Constants.Bonfire},
                        new SoundSample{Name=AppResource.Night, Icon = Helpers.ImageNameHelper.NightForest, Path = Constants.Constants.Night},
                        new SoundSample{Name=AppResource.Snowstorm, Icon = Helpers.ImageNameHelper.SnowStorm, Path = Constants.Constants.Snowstorm}
                    }
                },
                new Category
                {
                    Title = AppResource.Technick,
                    BackgroundImage = Helpers.ImageNameHelper.BgImage1,
                    GradientEndColor = Color.FromHex("#66e1e3"),
                    SoundsList = new List<SoundSample>
                    {
                        new SoundSample{Name=AppResource.City, Icon = Helpers.ImageNameHelper.City, Path = Constants.Constants.City},
                        new SoundSample{Name=AppResource.Helicopter, Icon = Helpers.ImageNameHelper.Helicopter, Path = Constants.Constants.Helicopter},
                        new SoundSample{Name=AppResource.Keyboard, Icon = Helpers.ImageNameHelper.Keyboard, Path = Constants.Constants.Keyboard},
                        new SoundSample{Name=AppResource.Mixer, Icon = Helpers.ImageNameHelper.Mixer, Path = Constants.Constants.Mixer},
                        new SoundSample{Name=AppResource.CoffeeMashine, Icon = Helpers.ImageNameHelper.CoffeeMashine, Path = Constants.Constants.CoffeeMashine},
                        new SoundSample{Name=AppResource.Train, Icon = Helpers.ImageNameHelper.Train, Path = Constants.Constants.Train},
                        new SoundSample{Name=AppResource.Calculator, Icon = Helpers.ImageNameHelper.Calculator, Path = Constants.Constants.Calculator},
                        new SoundSample{Name=AppResource.Laminator, Icon = Helpers.ImageNameHelper.Laminator, Path = Constants.Constants.Laminator},
                        new SoundSample{Name=AppResource.Sail, Icon = Helpers.ImageNameHelper.Sail, Path = Constants.Constants.Sail}
                    }
                },
                new Category
                {
                    Title = AppResource.ASMR,
                    BackgroundImage = Helpers.ImageNameHelper.BgImage2,
                    GradientEndColor = Color.FromHex("#99ebec"),
                    SoundsList = new List<SoundSample>
                    {
                        new SoundSample{Name=AppResource.Cats, Icon = Helpers.ImageNameHelper.Cat, Path = Constants.Constants.Cat},
                        new SoundSample{Name=AppResource.Birds, Icon = Helpers.ImageNameHelper.Bird, Path = Constants.Constants.Birds},
                        new SoundSample{Name=AppResource.Sea, Icon = Helpers.ImageNameHelper.UnderWater, Path = Constants.Constants.UnderWater},
                        new SoundSample{Name=AppResource.Snow, Icon = Helpers.ImageNameHelper.Snow, Path = Constants.Constants.Snow},
                        new SoundSample{Name=AppResource.Pen, Icon = Helpers.ImageNameHelper.Pen, Path = Constants.Constants.Pen},
                        new SoundSample{Name=AppResource.Pencil, Icon = Helpers.ImageNameHelper.Pencil, Path = Constants.Constants.Pencil},
                        new SoundSample{Name=AppResource.Scissors, Icon = Helpers.ImageNameHelper.Scissors, Path = Constants.Constants.Scissors},
                        new SoundSample{Name=AppResource.Chalk, Icon = Helpers.ImageNameHelper.Chalk, Path = Constants.Constants.Chalk},
                        new SoundSample{Name=AppResource.Clock, Icon = Helpers.ImageNameHelper.Clock, Path = Constants.Constants.Clock}

                    }
                },
                new Category
                {
                    Title = AppResource.Instrumental,
                    BackgroundImage = Helpers.ImageNameHelper.BgImage3,
                    GradientEndColor = Color.DarkGray,
                    SoundsList = new List<SoundSample>
                    {
                        new SoundSample{Name=AppResource.Harp, Icon = Helpers.ImageNameHelper.Harp, Path = Constants.Constants.Harp},
                        new SoundSample{Name=AppResource.Flute, Icon = Helpers.ImageNameHelper.Flute, Path = Constants.Constants.Flute},
                        new SoundSample{Name=AppResource.Tambourine, Icon = Helpers.ImageNameHelper.Tambourine, Path = Constants.Constants.Tambourine},
                        new SoundSample{Name=AppResource.Piano, Icon = Helpers.ImageNameHelper.Piano, Path = Constants.Constants.Piano},
                        new SoundSample{Name=AppResource.Guitar, Icon = Helpers.ImageNameHelper.Guitar, Path = Constants.Constants.Guitar},
                        new SoundSample{Name=AppResource.Xylophone, Icon = Helpers.ImageNameHelper.Xylophone, Path = Constants.Constants.Xylophone},
                        new SoundSample{Name=AppResource.ElectricGuitar, Icon = Helpers.ImageNameHelper.ElectricGuitar, Path = Constants.Constants.ElectricGuitar},
                        new SoundSample{Name=AppResource.Saxophone, Icon = Helpers.ImageNameHelper.Saxophone, Path = Constants.Constants.Saxophone},
                        new SoundSample{Name=AppResource.Meditation, Icon = Helpers.ImageNameHelper.Meditation, Path = Constants.Constants.Meditation},

                    }
                }
            };
        }
    }
}
