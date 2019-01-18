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
            switch (easyIcons)
            {
                case EasyIcons.Logo:
                    return "\uF681";
                default:
                    return "";
            }
        }

        public enum EasyIcons
        {
            Logo = 0
        }
	}
}