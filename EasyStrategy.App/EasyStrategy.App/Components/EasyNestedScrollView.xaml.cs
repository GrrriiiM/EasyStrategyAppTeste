using EasyStrategy.App.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStrategy.App.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EasyNestedScrollView : ScrollView
	{
		public EasyNestedScrollView ()
		{
			InitializeComponent ();
		}

        public Action<double> SetScrollY { get; set; }
        public Action<double> SetScrollX { get; set; }
        public bool CanScroll{ get; set; }

        public bool ScrollingAnimating { get; set; }

        public async Task ScrollXTo(double x)
        {
            if (ScrollingAnimating) return;
            if (this.ScrollX == x) return;
            var anim = new Animation(i =>
            {
                this.SetScrollX(i);
            },
            this.ScrollX,
            x,
            Easing.CubicOut);


            ScrollingAnimating = true;
            this.Animate("scrollXTo", anim, length: 150, rate: 32, finished: (a2, a1) => ScrollingAnimating = false);
        }
    }
}