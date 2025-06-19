using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UAS.ViewModel
{
    public partial class AppShellViewModel : BaseViewModel
    {

        [RelayCommand]
        async void SignOut()
        {
            Preferences.Remove("UserName");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }             

        
    }
}
