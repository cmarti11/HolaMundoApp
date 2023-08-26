using HolaMundoApp.Data.Models;
using HolaMundoApp.Services;
using HolaMundoApp.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace HolaMundoApp.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;

        public ClientsViewModel(IClientService clientService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            ClientTappedCommand = new AsyncCommand<Client>(OnClientTapped);
            RefreshCommand = new AsyncCommand(OnRefresh);
            Title = "Clients";
            _clientService = clientService;
        }

        private bool _isRefreshing = false;

        public bool IsRefreshing { get => _isRefreshing; set => SetProperty(ref _isRefreshing, value); }

        public ObservableRangeCollection<Client> Clients { get; set; } = new ObservableRangeCollection<Client>();

        public ICommand AppearingCommand { get; set; }
        public ICommand ClientTappedCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        private async Task OnAppearingAsync()
        {
            IsRefreshing = true;
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var clients = await _clientService.GetClients();
                if (clients != null)
                {
                    Clients.ReplaceRange(clients);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Task OnClientTapped(Client client)
        {
            if (client == null)
            {
                return Task.CompletedTask;
            }

            return Shell.Current.GoToAsync($"{nameof(ClientPage)}?{nameof(ClientViewModel.ClientId)}={client.Id}");
        }

        private async Task OnRefresh()
        {
            await LoadData();
            IsRefreshing = false;
        }

    }
}
