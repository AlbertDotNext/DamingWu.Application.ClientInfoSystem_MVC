﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IInteractionRepository : IAsyncRepository<Interaction>
    {
        Task<IEnumerable<Interaction>> GetInteractions();
    }
}
