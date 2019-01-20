using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStrategy.App.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EasyBoxView : ContentView
	{
		public EasyBoxView ()
		{
			InitializeComponent ();
		}

        public bool IsSquare { get; set; }

        public double SquareHeightProportion { get; set; } = 1;



        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(this.Height))
            {
                if (this.Height * this.SquareHeightProportion != this.Width && this.IsSquare)
                {
                    this.WidthRequest = this.Height / this.SquareHeightProportion;
                }
            }

            if (propertyName == nameof(this.Width))
            {
                if (this.Height * this.SquareHeightProportion != this.Width && this.IsSquare)
                {
                    this.HeightRequest = this.Width * this.SquareHeightProportion;
                }
            }
        }

    }
}
