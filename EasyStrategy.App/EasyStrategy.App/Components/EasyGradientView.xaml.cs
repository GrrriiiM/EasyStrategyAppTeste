using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStrategy.App.Components
{
    public enum GradientOrientation

    {
        Vertical,
        Horizontal
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EasyGradientView : ContentView
	{
		public EasyGradientView()
		{
			InitializeComponent ();
		}

        public GradientOrientation Orientation
        {
            get { return (GradientOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create<EasyGradientView, GradientOrientation>(x => x.Orientation, GradientOrientation.Vertical, BindingMode.OneWay);

        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public static readonly BindableProperty StartColorProperty =
            BindableProperty.Create<EasyGradientView, Color>(x => x.StartColor, Color.White, BindingMode.OneWay);
        
        public Color EndColor

        {

            get { return (Color)GetValue(EndColorProperty); }

            set { SetValue(EndColorProperty, value); }

        }

        public static readonly BindableProperty EndColorProperty =
            BindableProperty.Create<EasyGradientView, Color>(x => x.EndColor, Color.Black, BindingMode.OneWay);


    }



}