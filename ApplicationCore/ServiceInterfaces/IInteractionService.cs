﻿using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionService
    {
        Task<List<InteractionResponseModel>> GetInteractions();
        Task<InteractionResponseModel> AddInteraction(InteractionRequestModel model);
        Task<InteractionResponseModel> UpdateInteraction(int id, InteractionRequestModel model);
        Task<List<InteractionResponseModel>> GetClientInteractionsById(int id);
        Task<List<InteractionResponseModel>> GetEmployeeInteractionsById(int id);
        Task DeleteInteraction(int id);
    }
}
