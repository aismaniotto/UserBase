using System;
using System.Collections.Generic;
using UserBase.ViewModels;
using Xamarin.Forms;

namespace UserBase.Presentation.Pages
{
    public partial class UserForm : ContentPage
    {
        public UserForm()
        {
            InitializeComponent();
            BindingContext = new UserFormViewModel();
        }
    }
}
