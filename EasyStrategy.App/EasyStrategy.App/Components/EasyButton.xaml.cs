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
	public partial class EasyButton : EasyAbsoluteLayout
    {
		public EasyButton ()
		{
			InitializeComponent ();
		}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                shadow.Opacity = 0;
                shadow.IsVisible = true;
                await shadow.FadeTo(0.4, 50, Easing.CubicOut);
                await shadow.FadeTo(0, 100, Easing.CubicOut);
                shadow.IsVisible = false;
            });

        }

        

        public View Content { get => this.content.Content; set => this.content.Content = value; }
    }
}