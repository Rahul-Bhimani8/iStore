using Microsoft.Maui.Controls;

namespace iStore.Pages
{
    public partial class AdminDashboard : ContentPage
    {
        private int count = 0; // Consider using this field or removing it if not needed

        public AdminDashboard()
        {

            Content = new Label { Text = "Welcome, Admin!" };

           // InitializeComponent(); // This should now refer to the auto-generated method
            ProfilePage = new NavigationPage(new ProfilePage());
        }

        public NavigationPage ProfilePage { get; }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Optionally, insert logic here to determine if navigation should proceed
            await Navigation.PushAsync(new ProfilePage());
        }

        // Any additional methods or logic for your page
    }
}
