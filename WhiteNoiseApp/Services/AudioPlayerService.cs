using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WhiteNoiseApp.Interfaces;
using Xamarin.Forms;

namespace WhiteNoiseApp.Services
{
    public class AudioPlayerService : IAudioPlayerService
    {
        private readonly ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;

        public void OnVolumeChanged(object sender, ValueChangedEventArgs e)
        {
            
        }

        public void Pause()
        {
            if (player.IsPlaying)
            {
                player.Pause();
            }
            else
            {
                player.Play();
            }
        }

        public void Play(string path)
        {
            player.Load(GetStreamFromFile(path));
            player.Play();
            player.Loop = true;
        }

        public void Stop()
        {
            player.Stop();
        }


        private Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("WhiteNoiseApp.Sounds." + filename);
            return stream;
        }
    }
}
