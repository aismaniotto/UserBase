using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using UserBase.DataAccess.Repositories;
using UserBase.Entities;
using Xamarin.Forms;

namespace UserBase.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ICommand SelectUserCommand { get; set; }

        private List<User> _users;
        public List<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        private IRepository<User> _userRepository { get; set; }

        public UsersViewModel()
        {
            _userRepository = new UserRepository();
            LoadUsers();

            SelectUserCommand = new Command<User>(async (user) => await SelectUserCommandAction(user));
        }

        private async void LoadUsers()
        {
            try
            {
                IsBusy = true;
                Users = (List<User>) await _userRepository.GetAll();
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Something wrong",
                    "Some unnexpectable error happens. Please try again",
                    "Ok");

                await Application.Current.MainPage.Navigation.PopAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task SelectUserCommandAction(User user)
        {
            await Application.Current.MainPage.DisplayAlert(
                   "Details",
                   user.ToString(),
                   "Ok");
        }
    }
}

