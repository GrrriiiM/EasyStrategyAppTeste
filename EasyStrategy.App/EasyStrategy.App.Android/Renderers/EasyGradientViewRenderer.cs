using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Android.Views;
using EasyStrategy.App.Components;
using EasyStrategy.App.Droid.Renderers;

[assembly: Xamarin.Forms.ExportRenderer(typeof(EasyGradientView), typeof(EasyGradientViewRenderer))]

namespace EasyStrategy.App.Droid.Renderers
{
    public class EasyGradientViewRenderer : ViewRenderer<EasyGradientView, View>
    {

        public EasyGradientViewRenderer(Android.Content.Context context)
            :base(context)
        {

        }

        public GradientDrawable GradientDrawable { get; set; }
        /// <summary>
        /// Gets the underlying element typed as an <see cref="GradientContentView"/>.
        /// </summary>
        private EasyGradientView EasyGradientView
        {
            get { return (EasyGradientView)Element; }
        }

        /// <summary>
        /// Setup the gradient layer
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<EasyGradientView> e)
        {
            base.OnElementChanged(e);

            if (EasyGradientView != null)
            {
                //ShapeDrawable sd = new ShapeDrawable(new RectShape());
                GradientDrawable = new GradientDrawable();
                GradientDrawable.SetColors(new int[] { EasyGradientView.StartColor.ToAndroid(), EasyGradientView.EndColor.ToAndroid() });
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (GradientDrawable != null && EasyGradientView != null)
            {

                if (e.PropertyName == EasyGradientView.StartColorProperty.PropertyName ||
                    e.PropertyName == EasyGradientView.EndColorProperty.PropertyName)
                {
                    GradientDrawable.SetColors(new int[] { EasyGradientView.StartColor.ToAndroid(), EasyGradientView.EndColor.ToAndroid() });
                    Invalidate();
                }

                if (e.PropertyName == Xamarin.Forms.VisualElement.WidthProperty.PropertyName ||
                    e.PropertyName == Xamarin.Forms.VisualElement.HeightProperty.PropertyName ||
                    e.PropertyName == EasyGradientView.OrientationProperty.PropertyName)
                {
                    Invalidate();
                }
            }
        }

        public override void Draw(Canvas canvas)
        {
            GradientDrawable.Bounds = canvas.ClipBounds;
            GradientDrawable.SetOrientation(EasyGradientView.Orientation == GradientOrientation.Vertical ? GradientDrawable.Orientation.TopBottom
                : GradientDrawable.Orientation.LeftRight);
            GradientDrawable.Draw(canvas);
        }
    }
}