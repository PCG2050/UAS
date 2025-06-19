using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using static System.Collections.Specialized.BitVector32;

namespace UAS.Views.KVK
{
    public partial class Page36 : ContentPage
    {
        public Page36()
        {
            InitializeComponent();
            BindingContext = new Page36ViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

    }
    public partial class Page36ViewModel : INotifyPropertyChanged
    {
        private string _participatingCenterLabel;
        public string ParticipatingCenterLabel
        {
            get => _participatingCenterLabel;
            set
            {
                _participatingCenterLabel = value;
                OnPropertyChanged();
            }
        }

        public Page36ViewModel()
        {
            ParticipatingCenterLabel = InsertLineBreaks("Crops grown &amp; produce sold as organic", 20);
           
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
