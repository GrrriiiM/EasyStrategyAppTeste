using EasyStrategy.App.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EasyStrategy.App.Components
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EasyColapseScrollView : EasyAbsoluteLayout, INotifyPropertyChanged
    {
		public EasyColapseScrollView()
		{
			InitializeComponent ();
            
        }

        public static readonly BindableProperty HeaderMaxHeightProperty =
                BindableProperty.Create("HeaderMaxHeight", typeof(double), typeof(EasyColapseScrollView), defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (b, o, v) =>
                {
                    ((EasyColapseScrollView)b).recalcValues();
                });
        public double HeaderMaxHeight
        {
            get => (double)GetValue(HeaderMaxHeightProperty);
            set => SetValue(HeaderMaxHeightProperty, value);
        }

        public static readonly BindableProperty HeaderMinHeightProperty =
                BindableProperty.Create("HeaderMinHeight", typeof(double), typeof(EasyColapseScrollView),
                propertyChanged: (b, o, v) =>
                {
                    ((EasyColapseScrollView)b).recalcValues();
                });
        public double HeaderMinHeight
        {
            get => (double)GetValue(HeaderMinHeightProperty);
            set => SetValue(HeaderMinHeightProperty, value);
        }

        public static readonly BindableProperty HeaderStartHeightProperty =
                BindableProperty.Create("HeaderStartHeight", typeof(double), typeof(EasyColapseScrollView), defaultValue: -1D,
                propertyChanged: (b, o, v) =>
                {
                    ((EasyColapseScrollView)b).recalcValues();
                });
        public double HeaderStartHeight
        {
            get => (double)GetValue(HeaderStartHeightProperty);
            set => SetValue(HeaderStartHeightProperty, value);
        }

        public View Content
        {
            get=> this.content.Content;
            set=> this.content.Content = value;
        }

        public View Header
        {
            get => this.header.Content;
            set => this.header.Content = value;
        }

        public event EventHandler<ObservableBehaviorEventArgs> ObservableColapseChanged;

        private void ObservablePropertyBehavior_ObservablePropertyChanged(object sender, Behaviors.ObservableBehaviorEventArgs e)
        {
            this.header.HeightRequest = observablePropertyBehavior.MaxValue * (1 - e.Proportion) + this.HeaderMinHeight;

            ObservableColapseChanged?.Invoke(this.header, new ObservableBehaviorEventArgs(e.Proportion));
        }


        private void recalcValues()
        {
            content.HeightRequest = App.ScreenHeight - (this.HeaderMinHeight);
            observablePropertyBehavior.MaxValue = this.HeaderMaxHeight - this.HeaderMinHeight;
            observablePropertyBehavior.MinValue = 0;
            headerSpace.HeightRequest = this.HeaderStartHeight > 0 ? this.HeaderStartHeight : this.HeaderMaxHeight;
            header.HeightRequest = headerSpace.HeightRequest;
        }

    }
}