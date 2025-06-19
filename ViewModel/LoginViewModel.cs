using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace UAS.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private object _selectedDepartment;

        [ObservableProperty]
        private object _selectedSubDepartment;

        private ObservableCollection<string> _departments;

        private ObservableCollection<string> _subDepartments;

        [ObservableProperty]
        private bool _isSubDepartmentVisible;

        public LoginViewModel()
        {
            Departments = new ObservableCollection<string>
            {
                "Farmers Training Institute (FTI)",
                "Staff Training Unit (STU)",
                "Farm Information Unit (FIU)",
                "Institute of Baking Technology and Value Addition (IBT&VA)",
                "Agricultural Technology Information Centre (ATIC)",
                "Distance Education Unit (DEU)",
                "Agricultural SCience Museum (ASM)",
                "National Agriculture Extension Project (NAEP)",
                "Extension Education Units (EEU)",
                "Krishi Vigyan Kendras (KVKs)"
            };

            SubDepartments = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Departments
        {
            get => _departments;
            set => SetProperty(ref _departments, value);
        }

        public ObservableCollection<string> SubDepartments
        {
            get => _subDepartments;
            set => SetProperty(ref _subDepartments, value);
        }

         
               
        partial void OnSelectedDepartmentChanged(object value)
        {
            if (SelectedDepartment as string == "Krishi Vigyan Kendras (KVKs)")
            {
                SubDepartments = new ObservableCollection<string>
                {
                    "KVK, Hassan",
                    "KVK, Tumukuru-1",
                    "KVK, Bengaluru Rural",
                    "KVK, Chikaballapur",
                    "KVK, Mandya"
                };
                IsSubDepartmentVisible = true;

            }
            else if(SelectedDepartment as string == "Extension Education Units (EEU)")
            {
                SubDepartments = new ObservableCollection<string>
                {
                    "EEU, Naganahalli, Mysore",
                    "EEU, Kolar"
                };
                IsSubDepartmentVisible= true;
            }
                       
            else
            {
                SubDepartments.Clear();
                IsSubDepartmentVisible = false;
            }
        }

        [RelayCommand]
        private async Task Login()
        {
            if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password))
            {
                Preferences.Set("UserName", UserName);
                await Shell.Current.GoToAsync("///Home");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Please enter both fields", "OK");
            }
        }
    }
}
