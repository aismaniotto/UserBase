using System;
using System.Collections.Generic;
using UserBase.ViewModels;
using Xamarin.Forms;

namespace UserBase.Presentation.Pages
{
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
            BindingContext = new UsersViewModel();
        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (BindingContext is UsersViewModel usersViewModel)
            {
                usersViewModel.SelectUserCommand.Execute(e.Item);
            }
        }
    }
}
