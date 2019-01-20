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
	public partial class EasyIcon : Label
	{
		public EasyIcon ()
		{
			InitializeComponent ();
		}

        private EasyIcons icon;

        public EasyIcons Icon
        {
            get { return icon; }
            set { icon = value; this.Text = easyIconsToString(value); }
        }

        private string easyIconsToString(EasyIcons easyIcons)
        {
            var icons = new string[]
            {
                "\uF681",
                "\uf201",
                "\uf4fe",
                "\uf3d1",
                "\uf1fe",
                "\uf200"
            };
            return icons[(int)easyIcons];
        }

        public enum EasyIcons
        {
            Logo = 0,
            Goal = 1,
            UserCog = 2,
            Money = 3,
            ChartArea = 4,
            ChartPie = 5
        }
	}
}