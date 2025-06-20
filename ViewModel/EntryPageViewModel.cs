using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace UAS.ViewModel
{
    public partial class EntryPageViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [ObservableProperty]
        private object _selectedDepartment;

        [ObservableProperty]
        private object _selectedSubDepartment;

        private ObservableCollection<string> _departments;

        private ObservableCollection<string> _subDepartments;

        [ObservableProperty]
        private bool _isSubDepartmentVisible;
        public EntryPageViewModel()
        {
            Sections = new ObservableCollection<string>
            {
                "OFT",
                "FLD",
                "Training Program",
                "Any Other Activities"
            };
        }
        public ObservableCollection<string> Sections { get; }

        private string selectedSection;
        public string SelectedSection
        {
            get => selectedSection;
            set
            {
                if (selectedSection != value)
                {
                    selectedSection = value;
                    OnPropertyChanged();
                    UpdateSectionVisibility();

                }
            }
        }
        //partial void OnSelectedDepartmentChanged(object value)
        //{
        //    if (SelectedDepartment as string == "Krishi Vigyan Kendras (KVKs)")
        //    {
        //        SubDepartments = new ObservableCollection<string>
        //        {
        //            "KVK, Hassan",
        //            "KVK, Tumukuru-1",
        //            "KVK, Bengaluru Rural",
        //            "KVK, Chikaballapur",
        //            "KVK, Mandya"
        //        };
        //        IsSubDepartmentVisible = true;

        //    }
        //    else if (SelectedDepartment as string == "Extension Education Units (EEU)")
        //    {
        //        SubDepartments = new ObservableCollection<string>
        //        {
        //            "EEU, Naganahalli, Mysore",
        //            "EEU, Kolar"
        //        };
        //        IsSubDepartmentVisible = true;
        //    }

        //    else
        //    {
        //        SubDepartments.Clear();
        //        IsSubDepartmentVisible = false;
        //    }
        //    OnPropertyChanged(nameof(SubDepartments));
        //    OnPropertyChanged(nameof(IsSubDepartmentVisible));
        //}



        public bool IsBorderVisible => !string.IsNullOrEmpty(SelectedSection);
        public bool IsOFTSelected { get; private set; }

        public bool IsFLDSelected { get; private set; }

        public bool IsTrainingProgramSelected { get; private set; }


        public bool IsOtherActivitiesSelected { get; private set; }

        private bool isOtherActivitiesSelected;


        private void UpdateSectionVisibility()
        {
            IsOFTSelected = SelectedSection == "OFT";
            IsFLDSelected = SelectedSection == "FLD";
            IsTrainingProgramSelected = SelectedSection == "Training Program";
            IsOtherActivitiesSelected = SelectedSection == "Any Other Activities";
            OnPropertyChanged(nameof(IsBorderVisible));
            OnPropertyChanged(nameof(IsOFTSelected));
            OnPropertyChanged(nameof(IsFLDSelected));
            OnPropertyChanged(nameof(IsOtherActivitiesSelected));
            OnPropertyChanged(nameof(IsTrainingProgramSelected));

        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
