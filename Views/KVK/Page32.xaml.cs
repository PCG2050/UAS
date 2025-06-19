using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Maui.Controls;

namespace UAS.Views.KVK
{
    public partial class Page32 : ContentPage
    {
        public Page32()
        {
            InitializeComponent();
            BindingContext = new Page32ViewModel();
        }

    }

    public class Page32ViewModel : INotifyPropertyChanged
    {
        private string _participatingCenterLabel;
        private string _selectedSection;
        private bool _isDiplomaSelected;
        private bool _isCertificateSelected;
        private bool _isOtherActivitiesSelected;
        private bool _isBorderVisible;

        public string ParticipatingCenterLabel
        {
            get => _participatingCenterLabel;
            set
            {
                _participatingCenterLabel = value;
                OnPropertyChanged();
            }
        }

        public Page32ViewModel()
        {
            ParticipatingCenterLabel = InsertLineBreaks("Participating center(ATIC/ other KVKs/Dept./etc.,)", 15);
            Sections = new ObservableCollection<string>
            {
                "Short messages to be sent to farmers for the coming month",
                "Expert center",
                "Other e-KVK activities"
            };
        }

        private string InsertLineBreaks(string text, int maxLength)
        {
            if (text.Length <= maxLength) return text;

            var result = new StringBuilder();
            int currentLength = 0;

            foreach (var word in text.Split(' '))
            {
                if (currentLength + word.Length + 1 > maxLength)
                {
                    result.Append("\n");
                    currentLength = 0;
                }

                result.Append(word + " ");
                currentLength += word.Length + 1;
            }

            return result.ToString();
        }

        public ObservableCollection<string> Sections { get; set; }

        public string SelectedSection
        {
            get => _selectedSection;
            set
            {
                if (_selectedSection != value)
                {
                    _selectedSection = value;
                    OnPropertyChanged();
                    UpdateSectionVisibility();
                    IsBorderVisible = !string.IsNullOrEmpty(_selectedSection); 
                }
            }
        }

        public bool IsDiplomaSelected
        {
            get => _isDiplomaSelected;
            set
            {
                if (_isDiplomaSelected != value)
                {
                    _isDiplomaSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsCertificateSelected
        {
            get => _isCertificateSelected;
            set
            {
                if (_isCertificateSelected != value)
                {
                    _isCertificateSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsOtherActivitiesSelected
        {
            get => _isOtherActivitiesSelected;
            set
            {
                if (_isOtherActivitiesSelected != value)
                {
                    _isOtherActivitiesSelected = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsBorderVisible
        {
            get => _isBorderVisible;
            set
            {
                if (_isBorderVisible != value)
                {
                    _isBorderVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        private void UpdateSectionVisibility()
        {
            IsDiplomaSelected = SelectedSection == "Short messages to be sent to farmers for the coming month";
            IsCertificateSelected = SelectedSection == "Expert center";
            IsOtherActivitiesSelected = SelectedSection == "Other e-KVK activities";
            OnPropertyChanged(nameof(IsDiplomaSelected));
            OnPropertyChanged(nameof(IsCertificateSelected));
            OnPropertyChanged(nameof(IsOtherActivitiesSelected));
            OnPropertyChanged(nameof(IsBorderVisible));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
