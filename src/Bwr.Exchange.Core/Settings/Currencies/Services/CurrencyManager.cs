using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Currencies.Services
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly IRepository<Currency> _currencyRepository;
        public CurrencyManager(IRepository<Currency> currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        public bool CheckIfNameAlreadyExist(string name)
        {
            var currency = _currencyRepository.FirstOrDefault(x => x.Name.Trim().Equals(name.Trim()));
            return currency != null ? true : false;
        }

        public bool CheckIfNameAlreadyExist(int id, string name)
        {
            var currency = _currencyRepository.FirstOrDefault(x => x.Id != id && x.Name.Trim().Equals(name.Trim()));
            return currency != null ? true : false;
        }

        public async Task DeleteAsync(int id)
        {
            var currency = await GetByIdAsync(id);
            if (currency != null)
                await _currencyRepository.DeleteAsync(currency);
        }

        public IList<Currency> GetAll()
        {
            return _currencyRepository.GetAll().ToList();
        }

        public async Task<IList<Currency>> GetAllAsync()
        {
            return await _currencyRepository.GetAllListAsync();
        }

        public async Task<Currency> GetByIdAsync(int id)
        {
            return await _currencyRepository.GetAsync(id);
        }

        public async Task<Currency> InsertAndGetAsync(Currency currency)
        {
            return await _currencyRepository.InsertAsync(currency);
        }

        public async Task<Currency> UpdateAndGetAsync(Currency currency)
        {
            return await _currencyRepository.UpdateAsync(currency);
        }


    }
}
