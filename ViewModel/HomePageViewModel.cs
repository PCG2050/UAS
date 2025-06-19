using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UAS.ViewModels
{
    public partial class HomePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public HomePageViewModel()
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
