using Microsoft.Maui.Controls;

namespace UberEatsClone.Views
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        private async void OnGetStartedClicked(object sender, EventArgs e)
        {
            // Navigate to MainPage (Bottom Tabs)
            await Navigation.PushAsync(new MainPage());
        }
    }
}
