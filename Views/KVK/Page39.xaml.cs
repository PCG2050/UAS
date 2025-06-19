using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;
using System.IO;
using System.Threading.Tasks;

namespace UAS.Views.KVK
{
    public partial class Page39 : ContentPage
    {
        public Page39()
        {
            InitializeComponent();
        }

        private async void OnUploadImageClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Please select an image file",
                    FileTypes = FilePickerFileType.Images
                });

                if (result != null)
                {
                    // Check image resolution and size
                    using (var stream = await result.OpenReadAsync())
                    {
                        var imageSource = ImageSource.FromStream(() => stream);
                        var memoryStream = new MemoryStream();
                        stream.CopyTo(memoryStream);
                        var imageData = memoryStream.ToArray();

                        // Ensure the image meets your size criteria
                        if (imageData.Length > 1024 * 1024) // For example, limit to 1MB
                        {
                            await DisplayAlert("Error", "Image size exceeds the limit of 1MB", "OK");
                            return;
                        }

                        UploadedImage.Source = imageSource;
                        UploadedImage.IsVisible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async void OnAttachDocumentClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Please select a document",
                    FileTypes = FilePickerFileType.Pdf // Adjust as needed
                });

                if (result != null)
                {
                    AttachedDocumentLabel.Text = $"Attached: {result.FileName}";
                    AttachedDocumentLabel.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Handle form submission logic here
            await DisplayAlert("Submitted", "Your form has been submitted", "OK");
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            // Handle the previous button click logic here
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            // Handle the add button click logic here
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            // Handle the next button click logic here
        }
    }
}
