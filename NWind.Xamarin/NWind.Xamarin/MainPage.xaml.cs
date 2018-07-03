using System;
using Xamarin.Forms;

namespace NWind.Xamarin
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private void btnCUD_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CUD());
        }
    }
}
