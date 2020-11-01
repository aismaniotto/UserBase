using System;
using System.Collections.Generic;
using UserBase.ViewModels;
using Xamarin.Forms;

namespace UserBase.Presentation.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}
