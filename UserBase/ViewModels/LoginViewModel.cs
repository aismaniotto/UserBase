using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using UserBase.Services;
using Xamarin.Forms;

namespace UserBase.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; private set; }

        public string Email { get; set; }
        public string Password { get; set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private readonly AuthProvider _authProvider;


        public LoginViewModel()
        {
            _authProvider = new AuthProvider(); 

            LoginCommand = new Command(async () => await LoginCommandAction());
        }


        public async Task LoginCommandAction()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var auth = await _authProvider.AuthAsync(Email, Password);

                Settings.AuthToken = auth.Token;
                Settings.User = Email;

            }
            catch (WebException)
            {
                await Application.Current.MainPage.DisplayAlert(
                     "No internet",
                     "Not possible to connect on internet. Please try again",
                     "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Something wrong",
                    "Some unnexpectable error happens.= Please try again",
                    "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
