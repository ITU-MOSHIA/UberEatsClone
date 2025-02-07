using Microsoft.Maui.Controls;

namespace TaskConnect.Views
{
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();
        }

        private async void OnFaqsClicked(object sender, EventArgs e)
        {
            // Open a new page or navigate to FAQs
            await DisplayAlert("FAQs", "This will show frequently asked questions.", "OK");
        }

        private async void OnContactSupportClicked(object sender, EventArgs e)
        {
            // Open email support or chat feature
            await DisplayAlert("Contact Support", "This will open contact support options.", "OK");
        }
    }
}
