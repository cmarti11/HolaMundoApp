using HolaMundoApp.Resx;
using HolaMundoApp.Views;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private string _username;
        private string _password;

        public string UserName { get => _username; set => SetProperty(ref _username, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public Command LoginCommand { get; }


        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if (ValidateFields())
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            } 
            else
            {
                await Application.Current.MainPage.DisplayAlert(AppResources.LoginPageInvalidLoginTitle,
                    AppResources.LoginPageInvalidLoginMessage, AppResources.OkText);
            }
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            return true;
        }

    }
}
