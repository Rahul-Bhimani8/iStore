// EmployeeDashboard.xaml.cs
using Microsoft.Maui.Controls;

namespace iStore.Pages
{
    public partial class EmployeeDashboard : ContentPage
    {
        
        public async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Optionally, insert logic here to determine if navigation should proceed
            await Navigation.PushAsync(new ProfilePage());
        }
    }
}
