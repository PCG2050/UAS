using System.Collections.ObjectModel;
using UAS.ViewModel;

namespace UAS
{


    public partial class LoginPage : ContentPage
    {    
      

        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();         
        }
        
        private async void TapGestureRecognizer_Tapped(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        private async void OnTermsAndConditionsTapped(object sender, EventArgs e)
        {            
            await Navigation.PushModalAsync(new TermsAndConditionsPage());
        }

     

        private async void ForgotPasswordTapped(object sender, EventArgs e)
        {
          
            await Navigation.PushAsync(new ForgotPasswordPage());
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }

}