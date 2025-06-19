using System;
using UAS.ViewModels;


namespace UAS.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel();
        }

       
       
    }
}