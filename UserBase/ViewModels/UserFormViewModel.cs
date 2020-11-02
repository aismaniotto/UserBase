using System;
using System.Threading.Tasks;
using System.Windows.Input;
using UserBase.DataAccess.Repositories;
using UserBase.Entities;
using UserBase.Validators;
using UserBase.Validators.Rules;
using Xamarin.Forms;

namespace UserBase.ViewModels
{
    public class UserFormViewModel : BaseViewModel
    {
        public ICommand SaveUserCommand { get; private set; }

        public ValidatableObject<string> Name { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> PhoneNumber { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> Email { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<string> Password { get; set; } = new ValidatableObject<string>();
        public ValidatableObject<DateTime> BirthDay { get; set; } = new ValidatableObject<DateTime>() { Value = DateTime.Now };

        private IRepository<User> _userRepository { get; set; }

        public UserFormViewModel()
        {
            _userRepository = new UserRepository();

            AddValidationRules();
            SaveUserCommand = new Command(async () =>  await SaveUserCommandAction());
        }

        private void AddValidationRules()
        {
            Name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Name Required" });

            PhoneNumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Phone Number Required" });
            PhoneNumber.Validations.Add(new IsLenghtValidRule<string> { ValidationMessage = "Phone Number should have a maximun of 10 digits and minimun of 8", MaximunLenght = 10, MinimunLenght = 8 });

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email Required" });
            Email.Validations.Add(new IsValidEmailRule<string> { ValidationMessage = "Invalid Email" });

            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password Required" });
            Password.Validations.Add(new IsValidPasswordRule<string> { ValidationMessage = "Password between 8-20 characters; must contain at least one lowercase letter, one uppercase letter, one numeric digit, and one special character" });

            BirthDay.Validations.Add(new HasValidAgeRule<DateTime> { ValidationMessage = "You must be 18 years of age or older" });

        }

        private bool AreFieldsValid()
        {
            bool isName = Name.Validate();
            bool isPhoneNumber = PhoneNumber.Validate();
            bool isEmailValid = Email.Validate();
            bool isPasswordValid = Password.Validate();
            bool isBirthday = BirthDay.Validate();

            return isName && isPhoneNumber && isEmailValid && isPasswordValid && isBirthday;
        }

        private async Task SaveUserCommandAction()
        {
            if (IsBusy || !AreFieldsValid()) return;

            try
            {
                IsBusy = true;
                var user = new User
                {
                    Name = Name.Value,
                    PhoneNumber = PhoneNumber.Value,
                    Email = Email.Value,
                    Password = Password.Value,
                    BirthDay = BirthDay.Value
                };
                await _userRepository.Add(user);

                await Application.Current.MainPage.DisplayAlert(
                    "Success",
                    "User saved!!",
                    "Ok");

                await Application.Current.MainPage.Navigation.PopAsync();

            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert(
                  "Something wrong",
                  "Some unnexpectable error happens. Please try again",
                  "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
