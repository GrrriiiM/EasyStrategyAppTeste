using EasyStrategy.App.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStrategy.App.Views.MainPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ResumeSalesValueCardView : EasyCardView
	{
		public ResumeSalesValueCardView ()
		{
			InitializeComponent ();
		}

        public string Title { get => this.title.Text; set => this.title.Text = value; }
        
        public static readonly BindableProperty ValueProperty =
                BindableProperty.Create("Value", typeof(double), typeof(ResumeSalesValueCardView), defaultValue: 0D,
                    propertyChanged: (b, o, n) =>
                    {
                        ((ResumeSalesValueCardView)b).valueLabel.Text = ((double)n).ToString("C0");
                    });
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public EasyIcon.EasyIcons Icon { get => this.icon.Icon; set => this.icon.Icon = value; }
    }
}