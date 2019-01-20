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
	public partial class HeaderView : EasyAbsoluteLayout
    {
		public HeaderView ()
		{
			InitializeComponent ();
		}

        private void ObservablePropertyBehavior_ObservablePropertyChanged(object sender, Behaviors.ObservableBehaviorEventArgs e)
        {
            double step0 = 0;
            double step1 = 0.5;


            this.headerExpanded.Opacity = 1 - ((1 - e.Proportion) / 0.5);
            this.headerExpanded.TranslationY = (this.headerExpanded.Height * (1 - e.Proportion)) * -0.1;

            
            this.headerColapsed.Opacity = (step1 - e.Proportion) / step1;
            this.headerColapsed.TranslationY = (this.headerColapsed.Height * (e.Proportion)) * -1;


        }
    }
}