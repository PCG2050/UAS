using Microsoft.Maui.Controls;
using System;
using UAS.ViewModel;

namespace UAS.Views
{
    public partial class ArticlesPage : ContentPage
    {
        public ArticlesPage()
        {
            InitializeComponent();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                var selectedPage = e.CurrentSelection[0] as string;
                var viewModel = BindingContext as ArticlesPageViewModel;
                if (viewModel != null)
                {
                    viewModel.SelectedPage = selectedPage;
                }
            }
        }
    }
}
