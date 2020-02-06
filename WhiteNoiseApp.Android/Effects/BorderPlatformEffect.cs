using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WhiteNoiseApp.Droid.Effects;
using WhiteNoiseApp.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(BorderPlatformEffect), "BorderLayoutEffect")]

namespace WhiteNoiseApp.Droid.Effects
{
    public class BorderPlatformEffect : BaseEffect
    {
        Android.Views.View _view;
        GradientDrawable _border;
        Android.Graphics.Color _color;
        int _width;
        float _radius;
        Border.BorderType _borderType;
        Drawable _orgDrawable;

        protected override void OnAttached()
        {
            UpdateBorderType();
            _view = Control ?? Container;

            _border = new GradientDrawable();
            _orgDrawable = _view.Background;

            UpdateRadius();
            UpdateWidth();
            UpdateColor();
            UpdateBorder();
        }

        protected override void OnDetached()
        {
            if (!IsDisposed)
            {
                // Check disposed
                _view.Background = _orgDrawable;
                if (Control == null)
                {
                    _view.SetPadding(0, 0, 0, 0);
                    _view.ClipToOutline = false;
                }
            }

            _border?.Dispose();
            _border = null;
            _view = null;
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (IsDisposed)
            {
                return;
            }

            if (args.PropertyName == Border.RadiusProperty.PropertyName)
            {
                UpdateRadius();
                UpdateBorder();
            }
            else if (args.PropertyName == Border.WidthProperty.PropertyName)
            {
                UpdateWidth();
                UpdateBorder();
            }
            else if (args.PropertyName == Border.ColorProperty.PropertyName)
            {
                UpdateColor();
                UpdateBorder();
            }
        }

        void UpdateRadius()
        {
            _radius = _view.Context.ToPixels(Border.GetRadius(Element));
        }

        void UpdateWidth()
        {
            _width = (int)_view.Context.ToPixels(Border.GetWidth(Element));
        }

        void UpdateColor()
        {
            _color = Border.GetColor(Element).ToAndroid();
        }

        void UpdateBorderType()
        {
            _borderType = Border.GetBorderType(Element);
        }


        void UpdateBorder()
        {
            if (_borderType == Border.BorderType.Dotted)
            {
                _border.SetStroke(_width, _color, 10, 10);
            }
            else
            {
                _border.SetStroke(_width, _color);
            }

            _border.SetCornerRadius(_radius);
            var formsBack = (Element as Xamarin.Forms.View).BackgroundColor;
            if (formsBack != Xamarin.Forms.Color.Default)
            {
                _border.SetColor(formsBack.ToAndroid());
            }

            if (Element is BoxView)
            {
                var foreColor = ((BoxView)Element).Color;
                if (foreColor != Xamarin.Forms.Color.Default)
                {
                    _border.SetColor(foreColor.ToAndroid());
                }
            }

            if (Control == null)
            {
                _view.SetPadding(_width, _width, _width, _width);
                if (Android.OS.Build.VERSION.SdkInt > BuildVersionCodes.Lollipop)
                {
                    _view.ClipToOutline = true; //not to overflow children
                }
            }

            _view.SetBackground(_border);



        }
    }
}