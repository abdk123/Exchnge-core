using Abp.Domain.Repositories;
using Bwr.Exchange.Settings.Companies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Services
{
    public class CompanyCashFlowManager : ICompanyCashFlowManager
    {
        private readonly IRepository<CompanyCashFlow> _companyCashFlowRepository;
        private readonly ICompanyManager _companyManager;

        public CompanyCashFlowManager(
            IRepository<CompanyCashFlow> companyCashFlowRepository,
            ICompanyManager companyManager
            )
        {
            _companyCashFlowRepository = companyCashFlowRepository;
            _companyManager = companyManager;
        }

        public async Task Create(CompanyCashFlow input)
        {
            await _companyCashFlowRepository.InsertAsync(input);
        }

        public IList<CompanyCashFlow> Get(int companyId)
        {
            var companyCashFlows = _companyCashFlowRepository
                .GetAllIncluding(
                cu => cu.Currency,
                tr => tr.Company)
                .Where(x => x.CompanyId == companyId);
            return companyCashFlows.ToList();
        }

        public async Task<CompanyCashFlow> GetLastAsync(int companyId, int currencyId)
        {
            CompanyCashFlow companyCashFlow = null;
            var companyCashFlows = await _companyCashFlowRepository
                .GetAllListAsync(x => x.CompanyId == companyId && x.CurrencyId == currencyId);
            if (companyCashFlows.Any())
            {
                companyCashFlow = companyCashFlows.OrderByDescending(x => x.Id).FirstOrDefault();
            }
            return companyCashFlow;
        }

        public IList<CompanyCashFlow> Get(int companyId, int currencyId, DateTime fromDate, DateTime toDate)
        {
            var companyCashFlows = _companyCashFlowRepository.GetAllIncluding(
                cu => cu.Currency,
                tr => tr.Company)
                .Where(x =>
                x.CompanyId == companyId &&
                x.CurrencyId == currencyId &&
                x.Date >= fromDate &&
                x.Date <= toDate);

            return companyCashFlows.ToList();
        }

        public double GetPreviousBalance(int companyId, int currencyId, DateTime date)
        {
            double balance = 0.0;
            var companyCashFlows = _companyCashFlowRepository
                .GetAllList(x => x.CompanyId == companyId && x.CurrencyId == currencyId && x.Date < date);

            if (companyCashFlows.Any())
            {
                balance = companyCashFlows.OrderByDescending(x => x.Id).FirstOrDefault().CurrentBalance;
            }
            else
            {
                var companyBalance = _companyManager.GetCompanyBalance(companyId, currencyId);
                balance = companyBalance != null ? companyBalance.Balance : 0.0;
            }

            return balance;
        }
    }
}
