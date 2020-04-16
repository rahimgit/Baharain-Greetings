using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Baharain_Greetings
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Mainpage2 : ContentPage
	{
		public Mainpage2 ()
		{
			InitializeComponent ();
            busyIndicator.IsVisible = true;
            webviewLayout.IsVisible = false;
            webView.Source = "https://bahraingreetings.com/my-account/";
            webView.Navigated += WebView_Navigated;



        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            busyIndicator.IsVisible = false;
            webviewLayout.IsVisible = true;

        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }

        void OnForwardButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }


        protected  override  bool OnBackButtonPressed()
        {

            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    bool result = await DisplayAlert("Message", "Do you want to exit?", "Yes", "No");

                    if (result==true)
                    {
                        if (Device.RuntimePlatform == Device.iOS)
                        {
                            //iOS stuff
                        }
                        else if (Device.RuntimePlatform == Device.Android)
                        {
                            System.Environment.Exit(0);
                            
                        }
                    }
                });

                
            }

            return true;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            busyIndicator.IsVisible = true;
            webviewLayout.IsVisible = false;
        }
    }
}