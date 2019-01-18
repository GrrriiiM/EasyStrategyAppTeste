using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EasyStrategy.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void EasyColapseScrollView_ObservableColapseChanged(object sender, Behaviors.ObservableBehaviorEventArgs e)
        {
            double step0 = 0;
            double step1 = 0.2;
            double step2 = 0.6;


            if (e.Proportion < step0)
            {
                header2.IsVisible = true;
                header2.Opacity = 1;
                header3.IsVisible = true;
                header3.Opacity = 1;
            }
            else
            {
                if (e.Proportion < step1)
                {
                    header2.IsVisible = true;
                    header2.Opacity = 1;
                    var p = (e.Proportion - step0) / (step1 - step0);
                    header3.IsVisible = true;
                    header3.Opacity = 1 - p;
                }
                else
                {
                    if (e.Proportion < step2)
                    {
                        header3.IsVisible = false;
                        var p = (e.Proportion - step1) / (step2 - step1);
                        header2.IsVisible = true;
                        header2.Opacity = 1 - p;
                    }
                    else
                    {
                        header2.IsVisible = false;
                        header2.Opacity = 0;
                    }
                }
                
            }

            
        }
    }
}
