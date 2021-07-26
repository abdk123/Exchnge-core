using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Bwr.Exchange.Settings.Currencies.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Currencies.Services
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly IRepository<Currency> _currencyRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public IEventBus EventBus { get; set; }
        public CurrencyManager(
            IRepository<Currency> currencyRepository,
            IUnitOfWorkManager unitOfWorkManager)
        {
            _currencyRepository = currencyRepository;
            _unitOfWorkManager = unitOfWorkManager;
            EventBus = NullEventBus.Instance;
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
            int currencyId = 0;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                currencyId = await _currencyRepository.InsertAndGetIdAsync(currency);
                EventBus.Trigger(new CurrencyCreatedData { CurrencyId = currencyId });

                unitOfWork.Complete();
            }
            return _currencyRepository.FirstOrDefault(currencyId);
        }

        public async Task<Currency> UpdateAndGetAsync(Currency currency)
        {
            return await _currencyRepository.UpdateAsync(currency);
        }


    }
}
