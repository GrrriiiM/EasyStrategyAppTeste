
using Android.Views;
using EasyStrategy.App.Components;
using EasyStrategy.App.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EasyNestedScrollView), typeof(EasyNestedScrollViewRenderer))]

namespace EasyStrategy.App.Droid.Renderers
{

    public class EasyNestedScrollViewRenderer : ScrollViewRenderer
    {

        double density = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;

        public EasyNestedScrollViewRenderer(Android.Content.Context context)
            : base(context)
        {
            this.SmoothScrollingEnabled = false;
            this.NestedScrollingEnabled = false;
            this.OverScrollMode = OverScrollMode.Never;
        }

        private EasyNestedScrollView elementForms
        {
            get
            {
                return (EasyNestedScrollView)this.Element;
            }
        }

        protected override void OnOverScrolled(int scrollX, int scrollY, bool clampedX, bool clampedY)
        {
            base.OnOverScrolled(scrollX, scrollY, clampedX, clampedY);
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                this.elementForms.SetScrollY = (d) => ScrollTo(0, (int)(d * density));
                this.elementForms.SetScrollX = (d) => {
                    ScrollTo((int)(d * density), 0);
                };
            }
        }

        public override bool OnTouchEvent(MotionEvent ev)
        {
            if (!this.elementForms.CanScroll)
                return false;

            return base.OnTouchEvent(ev);
        }


        public override bool OnNestedPreFling(Android.Views.View target, float velocityX, float velocityY)
        {
            if (CanScrollVertically((int)velocityY))
            {
                Fling((int)velocityY);
            }

            return base.OnNestedPreFling(target, velocityX, velocityY);
        }

        public override void OnNestedPreScroll(Android.Views.View target, int dx, int dy, int[] consumed)
        {

            if (dy > 0 && CanScrollVertically(1))
            {
                ScrollBy(0, dy);
                consumed[1] = dy;
                return;
            }

            base.OnNestedPreScroll(target, dx, dy, consumed);

        }

    }
}