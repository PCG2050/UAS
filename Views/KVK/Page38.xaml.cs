using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace UAS.Views.KVK
{
    public partial class Page38 : ContentPage
    {
        public Page38()
        {
            InitializeComponent();
            BindingContext = new Page38ViewModel();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

    }
    public partial class Page38ViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _participatingCenterLabel;

        [ObservableProperty]
        private string _participatingCenterLabel1;

        [ObservableProperty]
        private string _participatingCenterLabel2;


        public Page38ViewModel()
        {
            ParticipatingCenterLabel = InsertLineBreaks("No. of dealers enrolled", 20);
            ParticipatingCenterLabel1 = InsertLineBreaks("Topics covered in the class", 20);
            ParticipatingCenterLabel2 = InsertLineBreaks("Name & designation of the resource person", 20);

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