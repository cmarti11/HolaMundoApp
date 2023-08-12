using HolaMundoApp.Data.Dto;
using HolaMundoApp.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolaMundoApp.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetClients();
        Task<ClientDetailDto> GetClient(long clientId);

    }
}

