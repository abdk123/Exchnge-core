using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Clients.Services
{
    public class ClientManager : IClientManager
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<ClientPhone> _clientPhoneRepository;
        private readonly IRepository<ClientBalance> _clientBalanceRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public ClientManager(
            IRepository<Client> clientRepository,
            IRepository<ClientPhone> clientPhoneRepository,
            IRepository<ClientBalance> clientBalanceRepository,
            IUnitOfWorkManager unitOfWorkManager
            )
        {
            _clientRepository = clientRepository;
            _clientPhoneRepository = clientPhoneRepository;
            _clientBalanceRepository = clientBalanceRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public bool CheckIfNameAlreadyExist(string name)
        {
            var client = _clientRepository.FirstOrDefault(x => x.Name.Trim().Equals(name.Trim()));
            return client != null ? true : false;
        }

        public bool CheckIfNameAlreadyExist(int id, string name)
        {
            var client = _clientRepository.FirstOrDefault(x => x.Id != id && x.Name.Trim().Equals(name.Trim()));
            return client != null ? true : false;
        }

        public async Task DeleteAsync(int id)
        {
            var client = await GetByIdAsync(id);
            if (client != null)
                await _clientRepository.DeleteAsync(client);
        }

        public IList<Client> GetAll()
        {
            return _clientRepository.GetAll().ToList();
        }

        public async Task<IList<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllListAsync();
        }

        public IList<Client> GetAllWithDetail()
        {
            var clients = _clientRepository.GetAllIncluding(x => x.ClientPhones);
            return clients.ToList();
        }

        public Client GetByIdWithDetail(int id)
        {
            var client = GetAllWithDetail().FirstOrDefault(x => x.Id == id);
            return client;
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _clientRepository.GetAsync(id);
        }

        public async Task<Client> InsertAndGetAsync(Client client)
        {
            return await _clientRepository.InsertAsync(client);
        }

        public async Task<Client> UpdateAndGetAsync(Client client)
        {
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                var updatedClient = await _clientRepository.UpdateAsync(client);

                //Update client phones
                var clientPhones = client.ClientPhones.ToList();//Don't remove ToList()
                await RemoveClientPhones(updatedClient, clientPhones);
                await AddNewClientPhones(updatedClient, clientPhones);

                //Update client balances
                var clientBalances = client.ClientBalances.ToList();//Don't remove ToList()
                await RemoveClientBalances(updatedClient, clientBalances);
                await AddNewClientBalances(updatedClient, clientBalances);

                unitOfWork.Complete();
            }
            return await GetByIdAsync(client.Id);
        }

        #region Helper Methods
        private async Task RemoveClientPhones(Client client, IList<ClientPhone> newClientPhones)
        {
            var oldClientPhones = await _clientPhoneRepository.GetAllListAsync(x => x.ClientId == client.Id);

            foreach (var oldClientPhone in oldClientPhones)
            {
                var isExist = newClientPhones.Any(x => x.PhoneNumber == oldClientPhone.PhoneNumber.Trim());
                if (!isExist)
                {
                    await _clientPhoneRepository.DeleteAsync(oldClientPhone);
                }
            }
        }

        private async Task AddNewClientPhones(Client client, IList<ClientPhone> newClientPhones)
        {
            var oldClientPhones = await _clientPhoneRepository.GetAllListAsync(x => x.ClientId == client.Id);
            foreach (var newClientPhone in newClientPhones)
            {
                var isExist = oldClientPhones.Any(x => x.PhoneNumber == newClientPhone.PhoneNumber.Trim());
                if (!isExist)
                {
                    await _clientPhoneRepository.InsertAsync(newClientPhone);
                }
            }
        }
        private async Task RemoveClientBalances(Client client, IList<ClientBalance> newClientBalances)
        {
            var oldClientBalances = await _clientBalanceRepository.GetAllListAsync(x => x.ClientId == client.Id);

            foreach (var oldClientBalance in oldClientBalances)
            {
                var isExist = newClientBalances.Any(x => x.CurrencyId == oldClientBalance.CurrencyId);
                if (!isExist)
                {
                    await _clientBalanceRepository.DeleteAsync(oldClientBalance);
                }
            }
        }

        private async Task AddNewClientBalances(Client client, IList<ClientBalance> newClientBalances)
        {
            var oldClientBalances = await _clientBalanceRepository.GetAllListAsync(x => x.ClientId == client.Id);
            foreach (var newClientBalance in newClientBalances)
            {
                var isExist = oldClientBalances.Any(x => x.CurrencyId == newClientBalance.CurrencyId);
                if (!isExist)
                {
                    await _clientBalanceRepository.InsertAsync(newClientBalance);
                }
            }
        }
        #endregion
    }
}
