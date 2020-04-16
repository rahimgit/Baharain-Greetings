using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Baharain_Greetings
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Animate();
            

        }

        public async Task Animate() {
            imgLogo.Opacity = 0;
            await imgLogo.FadeTo(1,400);
            await Task.Delay(3000);

            Device.BeginInvokeOnMainThread(async () =>
            {
                Application.Current.MainPage = new Mainpage2();
              
            });
            
        }

       

    }
}
