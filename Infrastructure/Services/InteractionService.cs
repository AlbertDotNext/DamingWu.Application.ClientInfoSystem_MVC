﻿using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionRepository _interactionRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public InteractionService(IInteractionRepository interactionRepository, IClientRepository clientRepository, IEmployeeRepository employeeRepository)
        {
            _interactionRepository = interactionRepository;
            _clientRepository = clientRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<InteractionResponseModel> AddInteraction(InteractionRequestModel model)
        {
            var client = await _clientRepository.GetByIdAsync(model.ClientId);
            if(client == null)
            {
                throw new NotFoundException("Client does not exists");
            }
            var employee = await _employeeRepository.GetByIdAsync(model.EmpId);
            if(employee == null)
            {
                throw new NotFoundException("Employee does not exists");
            }
            var interaction = new Interaction
            {
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks
            };

            var createdInteraction = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };

            await _interactionRepository.AddAsync(interaction);
            return createdInteraction;
        }

        public async Task DeleteInteraction(int id)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);
            await _interactionRepository.DeleteAsync(interaction);
        }

        public async Task<List<InteractionResponseModel>> GetClientInteractionsById(int id)
        {
            var interactions = await _interactionRepository.GetClientInteractionsById(id);

            var interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                interactionList.Add(new InteractionResponseModel
                {
                    Id = interaction.Id,
                    ClientId = interaction.ClientId,
                    ClientName = interaction.Client.Name,
                    EmpId = interaction.EmpId,
                    EmployeeName = interaction.Emp.Name,
                    IntType = interaction.IntType,
                    IntDate = interaction.IntDate,
                    Remarks = interaction.Remarks
                });
            }

            return interactionList;
        }

        public async Task<List<InteractionResponseModel>> GetEmployeeInteractionsById(int id)
        {
            var interactions = await _interactionRepository.GetEmployeeInteractionsById(id);

            var interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                interactionList.Add(new InteractionResponseModel
                {
                    Id = interaction.Id,
                    ClientId = interaction.ClientId,
                    ClientName = interaction.Client.Name,
                    EmpId = interaction.EmpId,
                    EmployeeName = interaction.Emp.Name,
                    IntType = interaction.IntType,
                    IntDate = interaction.IntDate,
                    Remarks = interaction.Remarks
                });
            }

            return interactionList;
        }

        public async Task<List<InteractionResponseModel>> GetInteractions()
        {
            var interactions = await _interactionRepository.GetInteractions();
            var interactionList = new List<InteractionResponseModel>();
            foreach (var interaction in interactions)
            {
                interactionList.Add(new InteractionResponseModel
                {
                    Id = interaction.Id,
                    ClientId = interaction.ClientId,
                    ClientName = interaction.Client.Name,
                    EmpId = interaction.EmpId,
                    EmployeeName = interaction.Emp.Name,
                    IntType = interaction.IntType,
                    IntDate = interaction.IntDate,
                    Remarks = interaction.Remarks

                });
            }

            return interactionList;
        }

        public async Task<InteractionResponseModel> UpdateInteraction(int id, InteractionRequestModel model)
        {
            var interaction = await _interactionRepository.GetByIdAsync(id);
            if(interaction == null)
            {
                throw new NotFoundException("No interaction found");

            }

            interaction.ClientId = model.ClientId;
            interaction.EmpId = model.EmpId;
            interaction.IntType = model.IntType;
            interaction.IntDate = model.IntDate;
            interaction.Remarks = model.Remarks;

            var updatedInteraction = new InteractionResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };

            await _interactionRepository.UpdateAsync(interaction);
            return updatedInteraction;
        }
    }
}
