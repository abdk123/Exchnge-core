﻿using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Clients.Services
{
    public interface IClientManager : IDomainService
    {
        Task<IList<Client>> GetAllAsync();
        IList<Client> GetAllWithDetail();
        Client GetByIdWithDetail(int id);
        Task<Client> GetByIdAsync(int id);
        IList<Client> GetAll();
        Task<Client> InsertAndGetAsync(Client country);
        Task<Client> UpdateAndGetAsync(Client country);
        Task DeleteAsync(int id);
        bool CheckIfNameAlreadyExist(string name);
        bool CheckIfNameAlreadyExist(int id, string name);
    }
}
