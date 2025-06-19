using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace UAS.Views.KVK
{
    public partial class Page37 : ContentPage
    {
        public Page37()
        {
            InitializeComponent();
            BindingContext = new Page37ViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
       
    }
    public partial class Page37ViewModel : INotifyPropertyChanged
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

        public Page37ViewModel()
        {
            ParticipatingCenterLabel = InsertLineBreaks("Title of programme / activity conducted", 20);

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