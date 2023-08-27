using HolaMundoApp.Resx;
using HolaMundoApp.Services;
using HolaMundoApp.Views;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;

        public LoginViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            LoginCommand = new Command(OnLoginClicked);
        }

        private string _username = string.Empty;
        private string _password = string.Empty;

        public string UserName { get => _username; set => SetProperty(ref _username, value); }
        public string Password { get => _password; set => SetProperty(ref _password, value); }
        public Command LoginCommand { get; }


        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if (ValidateFields() && await _accountService.LoginAsync(UserName, Password))
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            } 
            else
            {
                MessagingCenter.Send(this, "Fail");
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
