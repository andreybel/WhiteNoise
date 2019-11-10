using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V4.View;
using Android.Util;
using WhiteNoiseApp.Droid.Effects;
using WhiteNoiseApp.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Тип или член устарел
[assembly: ExportRenderer(typeof(GradientBackgroundEffect), typeof(GradientBackgroundPlatformEffect))]
#pragma warning restore CS0612 // Тип или член устарел
namespace WhiteNoiseApp.Droid.Effects
{
    [Obsolete]
    public class GradientBackgroundPlatformEffect : VisualElementRenderer<StackLayout>
    {
        private Color StartColor { get; set; }
        private Color EndColor { get; set; }

        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {
            

            #region for Horizontal Gradient
            var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
            #endregion

                   this.StartColor.ToAndroid(),
                   this.EndColor.ToAndroid(),
                   Android.Graphics.Shader.TileMode.Mirror);

            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };
            paint.SetShader(gradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var stack = e.NewElement as GradientBackgroundEffect;
                this.StartColor = stack.StartColor;
                this.EndColor = stack.EndColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }
    }
}