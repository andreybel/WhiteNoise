using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WhiteNoiseApp.Interfaces
{
    public interface IAudioPlayerService
    {
        void Play(string path);
        void Stop();
        void Pause();
        void OnVolumeChanged(object sender, ValueChangedEventArgs e);
    }
}
