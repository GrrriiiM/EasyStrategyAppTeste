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
	public partial class PageView : EasyColapseScrollView
    {
		public PageView ()
		{
			InitializeComponent ();
		}
	}
}