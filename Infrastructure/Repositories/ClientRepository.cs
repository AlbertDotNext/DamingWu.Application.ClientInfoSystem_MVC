﻿using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository : EFRepository<Client>, IClientRepository
    {
        public ClientRepository(CISDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Client> GetClientByEmail(string email)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Email == email);
            return client;
        }
    }
}
