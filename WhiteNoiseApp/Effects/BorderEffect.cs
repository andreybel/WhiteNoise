using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace WhiteNoiseApp.Effects
{
    public static class Border
    {

        public enum BorderType
        {
            Solid,
            Dotted
        }

        public static readonly BindableProperty OnProperty =
            BindableProperty.CreateAttached(
                propertyName: "On",
                returnType: typeof(bool),
                declaringType: typeof(Border),
                defaultValue: false,
                propertyChanged: OnOffChanged
            );

        public static void SetOn(BindableObject view, bool value)
        {
            view.SetValue(OnProperty, value);
        }

        public static bool GetOn(BindableObject view)
        {
            return (bool)view.GetValue(OnProperty);
        }

        private static void OnOffChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
                return;

            if (GetBorderType(view) == BorderType.Solid && Device.RuntimePlatform == Device.iOS)
            {
                return;
            }
            if ((bool)newValue)
            {
                view.Effects.Add(new BorderEffect());
            }
            else
            {
                var toRemove = view.Effects.FirstOrDefault(e => e is BorderEffect);
                if (toRemove != null)
                    view.Effects.Remove(toRemove);
            }
        }

        public static readonly BindableProperty RadiusProperty =
            BindableProperty.CreateAttached(
                "Radius",
                typeof(double),
                typeof(Border),
                default(double)
            );

        public static void SetRadius(BindableObject view, double value)
        {
            view.SetValue(RadiusProperty, value);
        }

        public static double GetRadius(BindableObject view)
        {
            return (double)view.GetValue(RadiusProperty);
        }

        public static readonly BindableProperty WidthProperty =
            BindableProperty.CreateAttached(
                "Width",
                typeof(double),
                typeof(Border),
                default(double)
            );

        public static void SetWidth(BindableObject view, double value)
        {
            view.SetValue(WidthProperty, value);
        }

        public static double GetWidth(BindableObject view)
        {
            return (double)view.GetValue(WidthProperty);
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached(
                "Color",
                typeof(Color),
                typeof(Border),
                Color.Transparent
            );

        public static void SetColor(BindableObject view, Color value)
        {
            view.SetValue(ColorProperty, value);
        }

        public static Color GetColor(BindableObject view)
        {
            return (Color)view.GetValue(ColorProperty);
        }

        public static readonly BindableProperty BorderTypeProperty =
            BindableProperty.CreateAttached(
                "BorderType",
                typeof(BorderType),
                typeof(Border),
                BorderType.Solid
            );

        public static void SetBorderType(BindableObject view, BorderType value)
        {
            view.SetValue(BorderTypeProperty, value);
        }

        public static BorderType GetBorderType(BindableObject view)
        {
            return (BorderType)view.GetValue(BorderTypeProperty);
        }


        class BorderEffect : RoutingEffect
        {
            public BorderEffect() : base("WhiteNoiseApp.BorderPlatformEffect")
            {
            }
        }

    }
}
