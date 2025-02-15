﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IClientRepository : IAsyncRepository<Client>
    {
        Task<Client> GetClientByEmail(string email);
    }
}
