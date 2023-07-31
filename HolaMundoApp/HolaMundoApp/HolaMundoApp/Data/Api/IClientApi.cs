﻿using HolaMundoApp.Data.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HolaMundoApp.Data.API
{
    public interface IClientApi
    {
        [Get("/Clients")]
        Task<List<Client>> GetClients();
    }
}

