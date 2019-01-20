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
	public partial class EasyLabelButton : EasyButton
    {
		public EasyLabelButton ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty TextProperty =
                BindableProperty.Create("Text", typeof(string), typeof(EasyLabelButton),
                propertyChanged: (b, o, n) =>
                {
                    ((EasyLabelButton)b).label.Text = n.ToString();
                });
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty =
                BindableProperty.Create("FontSize", typeof(double), typeof(EasyLabelButton),
                propertyChanged: (b, o, n) =>
                {
                    ((EasyLabelButton)b).label.FontSize = (double)n;
                });
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
    }
}