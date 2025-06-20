using UAS.Views.KVK;

namespace UAS
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            LoadUserInfo();
            this.BindingContext = new AppShellViewModel();
            for (int i = 1; i <= 42; i++)
            {
                var pageType = Type.GetType($"UAS.Views.KVK.Page{i}");
                if (pageType != null)
                {
                    Routing.RegisterRoute($"Page{i}", pageType);
                }
            }
            Routing.RegisterRoute(nameof(EntryPage), typeof(EntryPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
            Routing.RegisterRoute(nameof(EditHistoryItemPage), typeof(EditHistoryItemPage));
        }

        private void LoadUserInfo()
        {
            string username = Preferences.Get("user_name", string.Empty);
            string role = "User";

            lblUserName.Text = username;
            lblUserRole.Text = role;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    using (var stream = await result.OpenReadAsync())
                    {
                        myImage.Source = ImageSource.FromStream(() => stream);
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }
}
