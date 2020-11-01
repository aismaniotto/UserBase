using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using UserBase.Services;
using UserBase.Validators;
using UserBase.Validators.Rules;
using Xamarin.Forms;

namespace UserBase.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; private set; }

        public ValidatableObject<string> Email { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> Password { get; set; } = new ValidatableObject<string>();

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private readonly AuthProvider _authProvider;


        public LoginViewModel()
        {
            AddValidationRules();
            _authProvider = new AuthProvider(); 

            LoginCommand = new Command(async () => await LoginCommandAction());
        }

        private void AddValidationRules()
        {
            //Email Validation Rules
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });

            //Password Validation Rules
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Validations.Add(new IsValidPasswordRule<string> { ValidationMessage = "Password between 8-20 characters; must contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character" });
        }


        bool AreFieldsValid()
        {
            bool isEmailValid = Email.Validate();
            bool isPasswordValid = Password.Validate();

            return isEmailValid && isPasswordValid;
        }

        private async Task LoginCommandAction()
        {
            if (IsBusy || !AreFieldsValid()) return;

            try
            {
                IsBusy = true;
                var auth = await _authProvider.AuthAsync(Email.Value, Password.Value);

                Settings.AuthToken = auth.Token;
                Settings.User = Email.Value;

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
