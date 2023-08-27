using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            MessagingCenter.Subscribe<LoginViewModel>(this, "Fail", (sender) =>
            {
                IncreaseFailureAttemptsCount();
            });

        }

        public ICommand OpenWebCommand { get; }
        private int _failureAttemptsCount = 0;

        public int FailureAttemptsCount { get => _failureAttemptsCount; set => SetProperty(ref _failureAttemptsCount, value); }

        private void IncreaseFailureAttemptsCount()
        {
            FailureAttemptsCount++;
        }

    }
}