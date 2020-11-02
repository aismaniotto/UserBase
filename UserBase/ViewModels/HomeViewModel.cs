using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UserBase.Presentation.Pages;
using UserBase.Services;
using Xamarin.Forms;

namespace UserBase.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand CreateNewUserCommand { get; private set; }
        public ICommand ListUsersCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }

        public string Email
        {
            get
            {
                return Settings.User;
            }
        }
        public string Profile { get; } = "Admin";
 
        public HomeViewModel()
        {
            CreateNewUserCommand = new Command(async () => await CreateNewUserCommandActionAsync());
            ListUsersCommand = new Command(async () => await ListUsersCommandAction());
            LogoutCommand = new Command(LogoutCommandAction);
        }

        private async Task CreateNewUserCommandActionAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UserForm());
        }

        private async Task ListUsersCommandAction()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new UsersPage());
        }

        private void LogoutCommandAction()
        {
            Settings.AuthToken = "";
            Settings.User = "";
            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }
    }
}
