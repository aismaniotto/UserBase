using System;
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
            CreateNewUserCommand = new Command(CreateNewUserCommandAction);
            ListUsersCommand = new Command(ListUsersCommandAction);
            LogoutCommand = new Command(LogoutCommandAction);
        }

        private void CreateNewUserCommandAction()
        {

        }

        private void ListUsersCommandAction()
        {

        }

        private void LogoutCommandAction()
        {
            Settings.AuthToken = "";
            Settings.User = "";
            Application.Current.MainPage = new NavigationPage(new LoginPage());

        }
    }
}
