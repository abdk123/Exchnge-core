using Abp.UI;
using Bwr.Exchange.Settings.Clients.Dto;
using Bwr.Exchange.Settings.Clients.Services;
using Bwr.Exchange.Shared.Dto;
using Bwr.Exchange.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Clients
{
    public class ClientAppService : ExchangeAppServiceBase, IClientAppService
    {
        private readonly IClientManager _countryManager;
        public ClientAppService(ClientManager countryManager)
        {
            _countryManager = countryManager;
        }

        public async Task<IList<ClientDto>> GetAllAsync()
        {
            var countries = await _countryManager.GetAllAsync();

            return ObjectMapper.Map<List<ClientDto>>(countries);
        }
        [HttpPost]
        public ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm)
        {
            var data = _countryManager.GetAllWithDetail();
            IEnumerable<ReadClientDto> countries = ObjectMapper.Map<List<ReadClientDto>>(data);

            var operations = new DataOperations();
            if (dm.Where != null && dm.Where.Count > 0)
            {
                countries = operations.PerformFiltering(countries, dm.Where, "and");
            }

            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                countries = operations.PerformSorting(countries, dm.Sorted);
            }

            IEnumerable groupDs = new List<ReadClientDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformSelect(countries, dm.Group);
            }

            var count = countries.Count();

            if (dm.Skip != 0)
            {
                countries = operations.PerformSkip(countries, dm.Skip);
            }

            if (dm.Take != 0)
            {
                countries = operations.PerformTake(countries, dm.Take);
            }

            return new ReadGrudDto() { result = countries, count = count, groupDs = groupDs };
        }
        public UpdateClientDto GetForEdit(int id)
        {
            var country =  _countryManager.GetByIdWithDetail(id);
            return ObjectMapper.Map<UpdateClientDto>(country);
        }
        public async Task<ClientDto> CreateAsync(CreateClientDto input)
        {
            CheckBeforeCreate(input);

            var country = ObjectMapper.Map<Client>(input);

            var createdClient = await _countryManager.InsertAndGetAsync(country);

            return ObjectMapper.Map<ClientDto>(createdClient);
        }
        public async Task<ClientDto> UpdateAsync(UpdateClientDto input)
        {
            CheckBeforeUpdate(input);

            var country = await _countryManager.GetByIdAsync(input.Id);

            ObjectMapper.Map<UpdateClientDto, Client>(input, country);

            var updatedClient = await _countryManager.UpdateAndGetAsync(country);

            return ObjectMapper.Map<ClientDto>(updatedClient);
        }
        public async Task DeleteAsync(int id)
        {
            await _countryManager.DeleteAsync(id);
        }

        #region Helper methods
        private void CheckBeforeCreate(CreateClientDto input)
        {
            var validationResultMessage = string.Empty;

            if (_countryManager.CheckIfNameAlreadyExist(input.Name))
            {
                validationResultMessage = L(ValidationResultMessage.NameAleadyExist);
            }

            if (!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }
        private void CheckBeforeUpdate(UpdateClientDto input)
        {
            var validationResultMessage = string.Empty;

            if (_countryManager.CheckIfNameAlreadyExist(input.Id, input.Name))
            {
                validationResultMessage = L(ValidationResultMessage.NameAleadyExist);
            }

            if (!string.IsNullOrEmpty(validationResultMessage))
                throw new UserFriendlyException(validationResultMessage);
        }

        

        #endregion
    }
}
