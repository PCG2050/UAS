namespace UAS.Views.KVK;

using System;
using Microsoft.Maui.Controls;

    public partial class Page28 : ContentPage
    {
        public Page28()
        {
            InitializeComponent();
            WrapLabels();
        }

        private void WrapLabels()
        {
            WrapLabel(typeOfPublicationLabel);
            WrapLabel(titleOfPublicationLabel);
            WrapLabel(authorsLabel);
            WrapLabel(newsPaperLabel);
            WrapLabel(dateLabel);
        }

        private void WrapLabel(Label label)
        {
            const int maxCharactersPerLine = 20;
            string originalText = label.Text;
            string wrappedText = InsertLineBreaks(originalText, maxCharactersPerLine);
            label.Text = wrappedText;
        }

        private string InsertLineBreaks(string text, int maxCharactersPerLine)
        {
            string[] words = text.Split(' ');
            string wrappedText = "";
            string line = "";

            foreach (string word in words)
            {
                if ((line + word).Length > maxCharactersPerLine)
                {
                    wrappedText += line.TrimEnd() + Environment.NewLine;
                    line = "";
                }
                line += word + " ";
            }

            wrappedText += line.TrimEnd(); // Add the last line

            return wrappedText;
        }


        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
