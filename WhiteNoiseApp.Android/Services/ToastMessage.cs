using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WhiteNoiseApp.Interfaces;

namespace WhiteNoiseApp.Droid.Services
{
    class ToastMessage : IToastMessage
    {
        public void ShowMessage(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }
    }
}