using UserBase.ViewModels;
using Xamarin.Forms;

namespace UserBase.Presentation.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
}
