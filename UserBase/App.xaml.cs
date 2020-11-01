using UserBase.Presentation.Pages;
using UserBase.Services;
using Xamarin.Forms;

namespace UserBase
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Settings.AuthToken == "")
                MainPage = new NavigationPage(new LoginPage());
            else
                MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
